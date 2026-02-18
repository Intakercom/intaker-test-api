using MediatR;
using TaskTrackingSystem.Application.Common;
using TaskTrackingSystem.Application.Common.Interfaces;
using TaskTrackingSystem.Application.Features.Sprints.DTOs;
using TaskTrackingSystem.Domain.Repositories;

namespace TaskTrackingSystem.Application.Features.Sprints.Queries.GetSprints;

public class GetSprintsQueryHandler : IRequestHandler<GetSprintsQuery, IReadOnlyList<SprintListDto>>
{
    private readonly ISprintRepository _sprintRepository;
    private readonly ICurrentUserService _currentUserService;
    private readonly ICacheService _cacheService;

    public GetSprintsQueryHandler(
        ISprintRepository sprintRepository,
        ICurrentUserService currentUserService,
        ICacheService cacheService)
    {
        _sprintRepository = sprintRepository;
        _currentUserService = currentUserService;
        _cacheService = cacheService;
    }

    public async Task<IReadOnlyList<SprintListDto>> Handle(GetSprintsQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyList<Domain.Entities.Sprint> sprints;

        if (_currentUserService.IsAdmin)
        {
            sprints = await _sprintRepository.GetAllAsync(cancellationToken);
        }
        else
        {
            var teamId = await _currentUserService.GetTeamIdAsync(cancellationToken)
                ?? throw new InvalidOperationException("User does not belong to a team.");

            var cacheKey = CacheKeys.SprintsByTeam(teamId);
            var cached = await _cacheService.GetAsync<List<SprintListDto>>(cacheKey, cancellationToken);
            if (cached is not null)
                return cached.AsReadOnly();

            sprints = await _sprintRepository.GetByTeamIdAsync(teamId, cancellationToken);

            var now = DateTime.UtcNow;
            var result = sprints
                .Select(s => new SprintListDto(
                    s.Id,
                    s.Name,
                    s.StartDate,
                    s.EndDate,
                    IsActive: s.StartDate <= now && s.EndDate >= now,
                    TaskCount: s.Tasks?.Count ?? 0,
                    TeamId: s.TeamId,
                    TeamName: s.Team.Name))
                .ToList();

            await _cacheService.SetAsync(cacheKey, result, TimeSpan.FromMinutes(10), cancellationToken);

            return result.AsReadOnly();
        }

        var nowUtc = DateTime.UtcNow;
        return sprints
            .Select(s => new SprintListDto(
                s.Id,
                s.Name,
                s.StartDate,
                s.EndDate,
                IsActive: s.StartDate <= nowUtc && s.EndDate >= nowUtc,
                TaskCount: s.Tasks?.Count ?? 0,
                TeamId: s.TeamId,
                TeamName: s.Team.Name))
            .ToList()
            .AsReadOnly();
    }
}
