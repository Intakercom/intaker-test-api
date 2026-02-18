using MediatR;
using TaskTrackingSystem.Application.Common;
using TaskTrackingSystem.Application.Common.Exceptions;
using TaskTrackingSystem.Application.Common.Interfaces;
using TaskTrackingSystem.Domain.Repositories;

namespace TaskTrackingSystem.Application.Features.Teams.Commands.AddTeamMember;

public class AddTeamMemberCommandHandler : IRequestHandler<AddTeamMemberCommand, Unit>
{
    private readonly ITeamRepository _teamRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICacheService _cacheService;

    public AddTeamMemberCommandHandler(
        ITeamRepository teamRepository,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork,
        ICacheService cacheService)
    {
        _teamRepository = teamRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _cacheService = cacheService;
    }

    public async Task<Unit> Handle(AddTeamMemberCommand request, CancellationToken cancellationToken)
    {
        var team = await _teamRepository.GetByIdAsync(request.TeamId, cancellationToken)
            ?? throw new NotFoundException(nameof(Domain.Entities.Team), request.TeamId);

        var user = await _userRepository.GetByEmailAsync(request.Email, cancellationToken)
            ?? throw new NotFoundException(nameof(Domain.Entities.User), request.Email);

        var oldTeamId = user.TeamId;

        user.TeamId = team.Id;
        _userRepository.Update(user);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        if (oldTeamId.HasValue)
        {
            await _cacheService.RemoveAsync(CacheKeys.TeamMembers(oldTeamId.Value), cancellationToken);
        }

        await _cacheService.RemoveAsync(CacheKeys.TeamMembers(request.TeamId), cancellationToken);

        return Unit.Value;
    }
}
