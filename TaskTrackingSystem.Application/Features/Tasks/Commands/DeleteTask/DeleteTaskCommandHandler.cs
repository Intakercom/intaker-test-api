using MediatR;
using TaskTrackingSystem.Application.Common;
using TaskTrackingSystem.Application.Common.Exceptions;
using TaskTrackingSystem.Application.Common.Interfaces;
using TaskTrackingSystem.Domain.Repositories;

namespace TaskTrackingSystem.Application.Features.Tasks.Commands.DeleteTask;

public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, Unit>
{
    private readonly ISprintTaskRepository _taskRepository;
    private readonly ISprintRepository _sprintRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICacheService _cacheService;

    public DeleteTaskCommandHandler(
        ISprintTaskRepository taskRepository,
        ISprintRepository sprintRepository,
        IUnitOfWork unitOfWork,
        ICacheService cacheService)
    {
        _taskRepository = taskRepository;
        _sprintRepository = sprintRepository;
        _unitOfWork = unitOfWork;
        _cacheService = cacheService;
    }

    public async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await _taskRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Domain.Entities.SprintTask), request.Id);

        var sprintId = task.SprintId;

        var sprint = await _sprintRepository.GetByIdAsync(sprintId, cancellationToken);

        _taskRepository.Remove(task);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        if (sprint is not null)
            await _cacheService.RemoveAsync(CacheKeys.SprintsByTeam(sprint.TeamId), cancellationToken);

        return Unit.Value;
    }
}
