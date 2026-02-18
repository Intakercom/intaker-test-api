using MediatR;
using TaskTrackingSystem.Application.Features.Teams.DTOs;

namespace TaskTrackingSystem.Application.Features.Teams.Queries.GetTeams;

public record GetTeamsQuery() : IRequest<IReadOnlyList<TeamDto>>;
