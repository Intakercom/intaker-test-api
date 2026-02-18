using MediatR;
using TaskTrackingSystem.Application.Features.Teams.DTOs;

namespace TaskTrackingSystem.Application.Features.Teams.Commands.CreateTeam;

public record CreateTeamCommand(string Name, string? Description) : IRequest<TeamDto>;
