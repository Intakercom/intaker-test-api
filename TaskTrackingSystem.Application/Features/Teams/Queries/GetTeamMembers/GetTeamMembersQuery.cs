using MediatR;
using TaskTrackingSystem.Application.Features.Teams.DTOs;

namespace TaskTrackingSystem.Application.Features.Teams.Queries.GetTeamMembers;

public record GetTeamMembersQuery(Guid TeamId) : IRequest<IReadOnlyList<TeamMemberDto>>;
