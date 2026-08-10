using MediatR;
using TaskTrackingSystem.Application.Common.Exceptions;
using TaskTrackingSystem.Application.Common.Interfaces;
using TaskTrackingSystem.Application.Features.Tasks.DTOs;
using TaskTrackingSystem.Domain.Entities;
using TaskTrackingSystem.Domain.Enums;
using TaskTrackingSystem.Domain.Repositories;

namespace TaskTrackingSystem.Application.Features.Tasks.Commands.UpdateTask;

public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, TaskDto>
{
    private readonly ISprintTaskRepository _taskRepository;
    private readonly ITaskHistoryRepository _taskHistoryRepository;
    private readonly ICurrentUserService _currentUserService;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTaskCommandHandler(
        ISprintTaskRepository taskRepository,
        ITaskHistoryRepository taskHistoryRepository,
        ICurrentUserService currentUserService,
        IUnitOfWork unitOfWork)
    {
        _taskRepository = taskRepository;
        _taskHistoryRepository = taskHistoryRepository;
        _currentUserService = currentUserService;
        _unitOfWork = unitOfWork;
    }

    public async Task<TaskDto> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await _taskRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Domain.Entities.SprintTask), request.Id);

        // Capture old values and detect changes
        var changes = new List<TaskHistory>();

        if (task.Title != request.Title)
        {
            changes.Add(CreateHistoryEntry(task.Id, TaskChangeType.TitleChanged, "Title", task.Title, request.Title));
        }

        if (task.Description != request.Description)
        {
            changes.Add(CreateHistoryEntry(task.Id, TaskChangeType.DescriptionChanged, "Description", task.Description, request.Description));
        }

        if (task.StoryPoints != request.StoryPoints)
        {
            changes.Add(CreateHistoryEntry(task.Id, TaskChangeType.StoryPointsChanged, "StoryPoints", task.StoryPoints?.ToString(), request.StoryPoints?.ToString()));
        }

        if (task.AssigneeId != request.AssigneeId)
        {
            changes.Add(CreateHistoryEntry(task.Id, TaskChangeType.AssigneeChanged, "AssigneeId", task.AssigneeId?.ToString(), request.AssigneeId?.ToString()));
        }

        // Update task
        task.Title = request.Title;
        task.Description = request.Description;
        task.StoryPoints = request.StoryPoints;
        task.AssigneeId = request.AssigneeId;

        _taskRepository.Update(task);

        // Add history entries
        foreach (var change in changes)
        {
            await _taskHistoryRepository.AddAsync(change, cancellationToken);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new TaskDto(
            task.Id, task.Title, task.Description, task.StoryPoints, task.Status.ToString(),
            task.AssigneeId, null, task.SprintId, task.CreatedByUserId,
            task.CreatedAtUtc, task.UpdatedAtUtc);
    }

    private TaskHistory CreateHistoryEntry(Guid taskId, TaskChangeType changeType, string fieldName, string? oldValue, string? newValue)
    {
        return new TaskHistory
        {
            Id = Guid.NewGuid(),
            TaskId = taskId,
            UserId = _currentUserService.UserId,
            ChangeType = changeType,
            FieldName = fieldName,
            OldValue = oldValue,
            NewValue = newValue,
            CreatedAtUtc = DateTime.UtcNow
        };
    }
}
