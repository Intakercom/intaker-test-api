using MediatR;
using TaskTrackingSystem.Application.Common;
using TaskTrackingSystem.Application.Common.Exceptions;
using TaskTrackingSystem.Application.Common.Interfaces;
using TaskTrackingSystem.Application.Features.Teams.DTOs;
using TaskTrackingSystem.Domain.Repositories;

namespace TaskTrackingSystem.Application.Features.Teams.Queries.GetTeamMembers;

public class GetTeamMembersQueryHandler : IRequestHandler<GetTeamMembersQuery, IReadOnlyList<TeamMemberDto>>
{
    private readonly ITeamRepository _teamRepository;
    private readonly ICacheService _cacheService;

    public GetTeamMembersQueryHandler(ITeamRepository teamRepository, ICacheService cacheService)
    {
        _teamRepository = teamRepository;
        _cacheService = cacheService;
    }

    public async Task<IReadOnlyList<TeamMemberDto>> Handle(GetTeamMembersQuery request, CancellationToken cancellationToken)
    {
        var cacheKey = CacheKeys.TeamMembers(request.TeamId);
        var cached = await _cacheService.GetAsync<List<TeamMemberDto>>(cacheKey, cancellationToken);
        if (cached is not null)
            return cached.AsReadOnly();

        var team = await _teamRepository.GetWithMembersAsync(request.TeamId, cancellationToken)
            ?? throw new NotFoundException(nameof(Domain.Entities.Team), request.TeamId);

        var members = team.Members
            .Select(m => new TeamMemberDto(m.Id, m.Email, m.FirstName, m.LastName, m.Role.ToString()))
            .ToList();

        await _cacheService.SetAsync(cacheKey, members, TimeSpan.FromMinutes(15), cancellationToken);

        return members.AsReadOnly();
    }
}
