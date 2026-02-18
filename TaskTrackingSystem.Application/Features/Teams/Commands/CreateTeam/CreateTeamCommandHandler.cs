using MediatR;
using TaskTrackingSystem.Application.Common.Interfaces;
using TaskTrackingSystem.Application.Features.Teams.DTOs;
using TaskTrackingSystem.Domain.Entities;
using TaskTrackingSystem.Domain.Enums;
using TaskTrackingSystem.Domain.Repositories;

namespace TaskTrackingSystem.Application.Features.Teams.Commands.CreateTeam;

public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommand, TeamDto>
{
    private readonly ITeamRepository _teamRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUserService;

    public CreateTeamCommandHandler(
        ITeamRepository teamRepository,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork,
        ICurrentUserService currentUserService)
    {
        _teamRepository = teamRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _currentUserService = currentUserService;
    }

    public async Task<TeamDto> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(_currentUserService.UserId, cancellationToken)
            ?? throw new UnauthorizedAccessException("User not found.");

        if (user.Role != TeamRole.Admin)
            throw new UnauthorizedAccessException("Only admin users can create teams.");

        var team = new Team
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description
        };

        await _teamRepository.AddAsync(team, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new TeamDto(team.Id, team.Name, team.Description, team.CreatedAtUtc);
    }
}
