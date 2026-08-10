using MediatR;
using TaskTrackingSystem.Application.Common.Exceptions;
using TaskTrackingSystem.Application.Common.Interfaces;
using TaskTrackingSystem.Domain.Entities;
using TaskTrackingSystem.Domain.Enums;
using TaskTrackingSystem.Domain.Repositories;

namespace TaskTrackingSystem.Application.Features.Tasks.Commands.UpdateTaskStatus;

public class UpdateTaskStatusCommandHandler : IRequestHandler<UpdateTaskStatusCommand, Unit>
{
    private readonly ISprintTaskRepository _taskRepository;
    private readonly ITaskHistoryRepository _taskHistoryRepository;
    private readonly ICurrentUserService _currentUserService;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTaskStatusCommandHandler(
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

    public async Task<Unit> Handle(UpdateTaskStatusCommand request, CancellationToken cancellationToken)
    {
        var task = await _taskRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Domain.Entities.SprintTask), request.Id);

        // Capture old status
        var oldStatus = task.Status;

        task.Status = request.Status;

        _taskRepository.Update(task);

        // Add status change history
        if (oldStatus != request.Status)
        {
            var history = new TaskHistory
            {
                Id = Guid.NewGuid(),
                TaskId = task.Id,
                UserId = _currentUserService.UserId,
                ChangeType = TaskChangeType.StatusChanged,
                FieldName = "Status",
                OldValue = oldStatus.ToString(),
                NewValue = request.Status.ToString(),
                CreatedAtUtc = DateTime.UtcNow
            };
            await _taskHistoryRepository.AddAsync(history, cancellationToken);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
