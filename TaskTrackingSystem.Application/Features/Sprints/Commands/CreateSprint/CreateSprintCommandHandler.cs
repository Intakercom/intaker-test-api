using MediatR;
using TaskTrackingSystem.Application.Common;
using TaskTrackingSystem.Application.Common.Exceptions;
using TaskTrackingSystem.Application.Common.Interfaces;
using TaskTrackingSystem.Application.Features.Sprints.DTOs;
using TaskTrackingSystem.Domain.Entities;
using TaskTrackingSystem.Domain.Repositories;

namespace TaskTrackingSystem.Application.Features.Sprints.Commands.CreateSprint;

public class CreateSprintCommandHandler : IRequestHandler<CreateSprintCommand, SprintDto>
{
    private readonly ISprintRepository _sprintRepository;
    private readonly ITeamRepository _teamRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUserService;
    private readonly ICacheService _cacheService;

    public CreateSprintCommandHandler(
        ISprintRepository sprintRepository,
        ITeamRepository teamRepository,
        IUnitOfWork unitOfWork,
        ICurrentUserService currentUserService,
        ICacheService cacheService)
    {
        _sprintRepository = sprintRepository;
        _teamRepository = teamRepository;
        _unitOfWork = unitOfWork;
        _currentUserService = currentUserService;
        _cacheService = cacheService;
    }

    public async Task<SprintDto> Handle(CreateSprintCommand request, CancellationToken cancellationToken)
    {
        Guid teamId;

        if (_currentUserService.IsAdmin)
        {
            teamId = request.TeamId
                ?? throw new InvalidOperationException("Admin users must specify a TeamId when creating a sprint.");

            _ = await _teamRepository.GetByIdAsync(teamId, cancellationToken)
                ?? throw new NotFoundException(nameof(Team), teamId);
        }
        else
        {
            teamId = await _currentUserService.GetTeamIdAsync(cancellationToken)
                ?? throw new InvalidOperationException("User does not belong to a team.");
        }

        var sprint = new Sprint
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            TeamId = teamId
        };

        await _sprintRepository.AddAsync(sprint, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        await _cacheService.RemoveAsync(CacheKeys.SprintsByTeam(teamId), cancellationToken);

        return new SprintDto(sprint.Id, sprint.Name, sprint.StartDate, sprint.EndDate, sprint.TeamId, sprint.CreatedAtUtc);
    }
}
