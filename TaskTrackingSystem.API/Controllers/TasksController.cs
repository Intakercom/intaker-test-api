using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskTrackingSystem.API.Middleware;
using TaskTrackingSystem.Application.Features.Tasks.Commands.CreateTask;
using TaskTrackingSystem.Application.Features.Tasks.Commands.DeleteTask;
using TaskTrackingSystem.Application.Features.Tasks.Commands.UpdateTask;
using TaskTrackingSystem.Application.Features.Tasks.Commands.UpdateTaskStatus;
using TaskTrackingSystem.Application.Features.Tasks.DTOs;
using TaskTrackingSystem.Application.Features.Tasks.Queries.GetTaskById;
using TaskTrackingSystem.Domain.Enums;

namespace TaskTrackingSystem.API.Controllers;

/// <summary>
/// Manage task cards within sprints.
/// Tasks represent work items on the sprint board and can be moved between status columns (ToDo, InProgress, Done).
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Authorize]
[Produces("application/json")]
public class TasksController : ControllerBase
{
    private readonly ISender _sender;

    public TasksController(ISender sender)
    {
        _sender = sender;
    }

    /// <summary>
    /// Create a new task in a sprint.
    /// </summary>
    /// <remarks>
    /// Creates a task card with the **ToDo** status by default.
    /// The task is assigned to the specified sprint and optionally to a user (assignee).
    ///
    /// Sample request:
    ///
    ///     POST /api/tasks
    ///     {
    ///         "title": "Implement login page",
    ///         "description": "Build the login form with email/password fields",
    ///         "assigneeId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///         "sprintId": "7c9e6679-7425-40de-944b-e07fc1f90ae7"
    ///     }
    ///
    /// </remarks>
    /// <param name="command">Task creation details.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The newly created task.</returns>
    /// <response code="200">Task created successfully.</response>
    /// <response code="400">Validation failed (e.g. missing title or sprintId).</response>
    /// <response code="401">User is not authenticated.</response>
    /// <response code="404">Sprint not found.</response>
    [HttpPost]
    [ProducesResponseType(typeof(TaskDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Create(CreateTaskCommand command, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Get a task by its unique identifier.
    /// </summary>
    /// <remarks>
    /// Returns the full details of a task including its status, assignee, sprint, and timestamps.
    /// </remarks>
    /// <param name="id">The unique identifier of the task.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The task details.</returns>
    /// <response code="200">Returns the task.</response>
    /// <response code="401">User is not authenticated.</response>
    /// <response code="404">Task not found.</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(TaskDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetTaskByIdQuery(id), cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Update an existing task's details.
    /// </summary>
    /// <remarks>
    /// Updates the title, description, and/or assignee of a task.
    /// This does **not** change the task's status — use `PATCH /api/tasks/{id}/status` for that.
    ///
    /// Sample request:
    ///
    ///     PUT /api/tasks/{id}
    ///     {
    ///         "title": "Implement login page (updated)",
    ///         "description": "Include forgot password link",
    ///         "assigneeId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
    ///     }
    ///
    /// </remarks>
    /// <param name="id">The unique identifier of the task to update.</param>
    /// <param name="request">Updated task details.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The updated task.</returns>
    /// <response code="200">Task updated successfully.</response>
    /// <response code="400">Validation failed.</response>
    /// <response code="401">User is not authenticated.</response>
    /// <response code="404">Task not found.</response>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(TaskDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateTaskRequest request, CancellationToken cancellationToken)
    {
        var command = new UpdateTaskCommand(id, request.Title, request.Description, request.AssigneeId);
        var result = await _sender.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Update a task's status (drag-and-drop).
    /// </summary>
    /// <remarks>
    /// Moves a task between board columns by changing its status.
    /// This is the endpoint called when a user drags a task card on the sprint board.
    ///
    /// Valid status values:
    /// - `0` = **ToDo**
    /// - `1` = **InProgress**
    /// - `2` = **Done**
    ///
    /// Sample request:
    ///
    ///     PATCH /api/tasks/{id}/status
    ///     {
    ///         "status": 1
    ///     }
    ///
    /// </remarks>
    /// <param name="id">The unique identifier of the task.</param>
    /// <param name="request">The new status value.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <response code="204">Task status updated successfully.</response>
    /// <response code="400">Validation failed (e.g. invalid status value).</response>
    /// <response code="401">User is not authenticated.</response>
    /// <response code="404">Task not found.</response>
    [HttpPatch("{id:guid}/status")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateStatus(Guid id, UpdateTaskStatusRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateTaskStatusCommand(id, request.Status), cancellationToken);
        return NoContent();
    }

    /// <summary>
    /// Delete a task.
    /// </summary>
    /// <remarks>
    /// Permanently removes a task from its sprint. This action cannot be undone.
    /// </remarks>
    /// <param name="id">The unique identifier of the task to delete.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <response code="204">Task deleted successfully.</response>
    /// <response code="401">User is not authenticated.</response>
    /// <response code="404">Task not found.</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteTaskCommand(id), cancellationToken);
        return NoContent();
    }
}

/// <summary>
/// Request body for updating task details (title, description, assignee).
/// </summary>
/// <param name="Title">The updated task title.</param>
/// <param name="Description">The updated task description (optional).</param>
/// <param name="AssigneeId">The user ID to assign the task to (optional, null to unassign).</param>
public record UpdateTaskRequest(string Title, string? Description, Guid? AssigneeId);

/// <summary>
/// Request body for updating a task's status (board column).
/// </summary>
/// <param name="Status">The new status: ToDo (0), InProgress (1), or Done (2).</param>
public record UpdateTaskStatusRequest(SprintTaskStatus Status);
