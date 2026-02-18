using MediatR;

namespace TaskTrackingSystem.Application.Features.Teams.Commands.AddTeamMember;

public record AddTeamMemberCommand(Guid TeamId, string Email) : IRequest<Unit>;
