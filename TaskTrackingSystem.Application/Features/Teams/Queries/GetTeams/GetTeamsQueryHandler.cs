using MediatR;
using TaskTrackingSystem.Application.Common.Interfaces;
using TaskTrackingSystem.Application.Features.Teams.DTOs;
using TaskTrackingSystem.Domain.Repositories;

namespace TaskTrackingSystem.Application.Features.Teams.Queries.GetTeams;

public class GetTeamsQueryHandler : IRequestHandler<GetTeamsQuery, IReadOnlyList<TeamDto>>
{
    private readonly ITeamRepository _teamRepository;
    private readonly ICurrentUserService _currentUserService;

    public GetTeamsQueryHandler(
        ITeamRepository teamRepository,
        ICurrentUserService currentUserService)
    {
        _teamRepository = teamRepository;
        _currentUserService = currentUserService;
    }

    public async Task<IReadOnlyList<TeamDto>> Handle(GetTeamsQuery request, CancellationToken cancellationToken)
    {
        if (_currentUserService.IsAdmin)
        {
            // Admin sees all teams
            var allTeams = await _teamRepository.GetAllAsync(cancellationToken);
            return allTeams
                .Select(t => new TeamDto(t.Id, t.Name, t.Description, t.CreatedAtUtc))
                .ToList()
                .AsReadOnly();
        }

        // Member sees only the team they belong to
        var teamId = await _currentUserService.GetTeamIdAsync(cancellationToken);
        if (!teamId.HasValue)
            return new List<TeamDto>().AsReadOnly();

        var team = await _teamRepository.GetByIdAsync(teamId.Value, cancellationToken);
        if (team is null)
            return new List<TeamDto>().AsReadOnly();

        return new List<TeamDto>
        {
            new(team.Id, team.Name, team.Description, team.CreatedAtUtc)
        }.AsReadOnly();
    }
}
