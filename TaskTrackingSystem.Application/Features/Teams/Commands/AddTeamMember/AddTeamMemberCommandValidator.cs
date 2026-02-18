using FluentValidation;

namespace TaskTrackingSystem.Application.Features.Teams.Commands.AddTeamMember;

public class AddTeamMemberCommandValidator : AbstractValidator<AddTeamMemberCommand>
{
    public AddTeamMemberCommandValidator()
    {
        RuleFor(x => x.TeamId).NotEmpty();
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
    }
}
