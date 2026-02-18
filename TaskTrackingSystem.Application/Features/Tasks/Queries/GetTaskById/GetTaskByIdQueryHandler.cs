using MediatR;
using TaskTrackingSystem.Application.Common.Exceptions;
using TaskTrackingSystem.Application.Features.Tasks.DTOs;
using TaskTrackingSystem.Domain.Repositories;

namespace TaskTrackingSystem.Application.Features.Tasks.Queries.GetTaskById;

public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, TaskDto>
{
    private readonly ISprintTaskRepository _taskRepository;

    public GetTaskByIdQueryHandler(ISprintTaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<TaskDto> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    {
        var task = await _taskRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Domain.Entities.SprintTask), request.Id);

        return new TaskDto(
            task.Id, task.Title, task.Description, task.Status.ToString(),
            task.AssigneeId, task.Assignee is not null ? $"{task.Assignee.FirstName} {task.Assignee.LastName}" : null,
            task.SprintId, task.CreatedByUserId,
            task.CreatedAtUtc, task.UpdatedAtUtc);
    }
}
