using MediatR;
using TaskTrackingSystem.Application.Common;
using TaskTrackingSystem.Application.Common.Exceptions;
using TaskTrackingSystem.Application.Common.Interfaces;
using TaskTrackingSystem.Application.Features.Tasks.DTOs;
using TaskTrackingSystem.Domain.Entities;
using TaskTrackingSystem.Domain.Enums;
using TaskTrackingSystem.Domain.Repositories;

namespace TaskTrackingSystem.Application.Features.Tasks.Commands.CreateTask;

public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, TaskDto>
{
    private readonly ISprintTaskRepository _taskRepository;
    private readonly ISprintRepository _sprintRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUserService;
    private readonly ICacheService _cacheService;

    public CreateTaskCommandHandler(
        ISprintTaskRepository taskRepository,
        ISprintRepository sprintRepository,
        IUnitOfWork unitOfWork,
        ICurrentUserService currentUserService,
        ICacheService cacheService)
    {
        _taskRepository = taskRepository;
        _sprintRepository = sprintRepository;
        _unitOfWork = unitOfWork;
        _currentUserService = currentUserService;
        _cacheService = cacheService;
    }

    public async Task<TaskDto> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var sprint = await _sprintRepository.GetByIdAsync(request.SprintId, cancellationToken)
            ?? throw new NotFoundException(nameof(Sprint), request.SprintId);

        var task = new SprintTask
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            Status = SprintTaskStatus.ToDo,
            AssigneeId = request.AssigneeId,
            SprintId = request.SprintId,
            CreatedByUserId = _currentUserService.UserId
        };

        await _taskRepository.AddAsync(task, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        await _cacheService.RemoveAsync(CacheKeys.SprintsByTeam(sprint.TeamId), cancellationToken);

        return new TaskDto(
            task.Id, task.Title, task.Description, task.Status.ToString(),
            task.AssigneeId, null, task.SprintId, task.CreatedByUserId,
            task.CreatedAtUtc, task.UpdatedAtUtc);
    }
}
