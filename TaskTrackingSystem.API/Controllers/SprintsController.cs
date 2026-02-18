using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskTrackingSystem.API.Middleware;
using TaskTrackingSystem.Application.Features.Sprints.Commands.CreateSprint;
using TaskTrackingSystem.Application.Features.Sprints.Commands.UpdateSprint;
using TaskTrackingSystem.Application.Features.Sprints.DTOs;
using TaskTrackingSystem.Application.Features.Sprints.Queries.GetSprintBoard;
using TaskTrackingSystem.Application.Features.Sprints.Queries.GetSprints;

namespace TaskTrackingSystem.API.Controllers;

/// <summary>
/// Manage sprints and view sprint boards.
/// Sprints are time-boxed iterations that belong to a team and contain tasks.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Authorize]
[Produces("application/json")]
public class SprintsController : ControllerBase
{
    private readonly ISender _sender;

    public SprintsController(ISender sender)
    {
        _sender = sender;
    }

    /// <summary>
    /// Create a new sprint.
    /// </summary>
    /// <remarks>
    /// Creates a sprint with a name, start date, and end date.
    ///
    /// - **Member** users: the sprint is automatically assigned to the user's current team. The `teamId` field is ignored.
    /// - **Admin** users: `teamId` is **required** — the sprint is created for the specified team.
    ///
    /// The end date must be after the start date.
    ///
    /// Sample request (Admin):
    ///
    ///     POST /api/sprints
    ///     {
    ///         "name": "Sprint 1",
    ///         "startDate": "2026-03-01T00:00:00Z",
    ///         "endDate": "2026-03-14T23:59:59Z",
    ///         "teamId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
    ///     }
    ///
    /// Sample request (Member):
    ///
    ///     POST /api/sprints
    ///     {
    ///         "name": "Sprint 1",
    ///         "startDate": "2026-03-01T00:00:00Z",
    ///         "endDate": "2026-03-14T23:59:59Z"
    ///     }
    ///
    /// </remarks>
    /// <param name="command">Sprint creation details.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The newly created sprint.</returns>
    /// <response code="200">Sprint created successfully.</response>
    /// <response code="400">Validation failed (e.g. missing name, end date before start date).</response>
    /// <response code="401">User is not authenticated.</response>
    /// <response code="404">Team not found (Admin only, when teamId is invalid).</response>
    /// <response code="409">User does not belong to a team (Member) or teamId not provided (Admin).</response>
    [HttpPost]
    [ProducesResponseType(typeof(SprintDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status409Conflict)]
    public async Task<IActionResult> Create(CreateSprintCommand command, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Update an existing sprint.
    /// </summary>
    /// <remarks>
    /// Updates the name, start date, and end date of a sprint.
    /// The end date must be after the start date.
    ///
    /// Sample request:
    ///
    ///     PUT /api/sprints/{id}
    ///     {
    ///         "name": "Sprint 1 (Extended)",
    ///         "startDate": "2026-03-01T00:00:00Z",
    ///         "endDate": "2026-03-21T23:59:59Z"
    ///     }
    ///
    /// </remarks>
    /// <param name="id">The unique identifier of the sprint to update.</param>
    /// <param name="request">Updated sprint details.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The updated sprint.</returns>
    /// <response code="200">Sprint updated successfully.</response>
    /// <response code="400">Validation failed.</response>
    /// <response code="401">User is not authenticated.</response>
    /// <response code="404">Sprint not found.</response>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(SprintDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateSprintRequest request, CancellationToken cancellationToken)
    {
        var command = new UpdateSprintCommand(id, request.Name, request.StartDate, request.EndDate);
        var result = await _sender.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Get all sprints visible to the current user.
    /// </summary>
    /// <remarks>
    /// - **Admin** users see all sprints across all teams.
    /// - **Member** users see only sprints belonging to their team.
    ///
    /// Each sprint includes:
    /// - `isActive` — true if the current date falls within the sprint's date range.
    /// - `taskCount` — total number of tasks in the sprint.
    /// - `teamId` — the unique identifier of the team the sprint belongs to.
    /// - `teamName` — the display name of the team the sprint belongs to.
    /// </remarks>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A list of sprints with summary information including team details.</returns>
    /// <response code="200">Returns the list of sprints.</response>
    /// <response code="401">User is not authenticated.</response>
    /// <response code="409">Member user does not belong to a team.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<SprintListDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status409Conflict)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetSprintsQuery(), cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Get the sprint board with tasks organized by status columns.
    /// </summary>
    /// <remarks>
    /// Returns the sprint's tasks grouped into three columns for a Kanban-style board:
    /// - **ToDo** — tasks not yet started
    /// - **InProgress** — tasks currently being worked on
    /// - **Done** — completed tasks
    ///
    /// Each task includes the assignee's name if one is assigned.
    /// This endpoint is intended for rendering the drag-and-drop sprint board UI.
    /// </remarks>
    /// <param name="id">The unique identifier of the sprint.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The sprint board with tasks grouped by status.</returns>
    /// <response code="200">Returns the sprint board.</response>
    /// <response code="401">User is not authenticated.</response>
    /// <response code="404">Sprint not found.</response>
    [HttpGet("{id:guid}/board")]
    [ProducesResponseType(typeof(SprintBoardDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetBoard(Guid id, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetSprintBoardQuery(id), cancellationToken);
        return Ok(result);
    }
}

/// <summary>
/// Request body for updating a sprint.
/// </summary>
/// <param name="Name">The updated sprint name.</param>
/// <param name="StartDate">The updated start date (UTC).</param>
/// <param name="EndDate">The updated end date (UTC). Must be after the start date.</param>
public record UpdateSprintRequest(string Name, DateTime StartDate, DateTime EndDate);
