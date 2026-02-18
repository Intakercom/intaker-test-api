using MediatR;
using TaskTrackingSystem.Application.Common.Exceptions;
using TaskTrackingSystem.Application.Features.Tasks.DTOs;
using TaskTrackingSystem.Domain.Repositories;

namespace TaskTrackingSystem.Application.Features.Tasks.Commands.UpdateTask;

public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, TaskDto>
{
    private readonly ISprintTaskRepository _taskRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTaskCommandHandler(ISprintTaskRepository taskRepository, IUnitOfWork unitOfWork)
    {
        _taskRepository = taskRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<TaskDto> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await _taskRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Domain.Entities.SprintTask), request.Id);

        task.Title = request.Title;
        task.Description = request.Description;
        task.AssigneeId = request.AssigneeId;

        _taskRepository.Update(task);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new TaskDto(
            task.Id, task.Title, task.Description, task.Status.ToString(),
            task.AssigneeId, null, task.SprintId, task.CreatedByUserId,
            task.CreatedAtUtc, task.UpdatedAtUtc);
    }
}
