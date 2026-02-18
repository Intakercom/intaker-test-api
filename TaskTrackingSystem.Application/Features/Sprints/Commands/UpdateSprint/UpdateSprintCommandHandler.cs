using MediatR;
using TaskTrackingSystem.Application.Common;
using TaskTrackingSystem.Application.Common.Exceptions;
using TaskTrackingSystem.Application.Common.Interfaces;
using TaskTrackingSystem.Application.Features.Sprints.DTOs;
using TaskTrackingSystem.Domain.Repositories;

namespace TaskTrackingSystem.Application.Features.Sprints.Commands.UpdateSprint;

public class UpdateSprintCommandHandler : IRequestHandler<UpdateSprintCommand, SprintDto>
{
    private readonly ISprintRepository _sprintRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICacheService _cacheService;

    public UpdateSprintCommandHandler(
        ISprintRepository sprintRepository,
        IUnitOfWork unitOfWork,
        ICacheService cacheService)
    {
        _sprintRepository = sprintRepository;
        _unitOfWork = unitOfWork;
        _cacheService = cacheService;
    }

    public async Task<SprintDto> Handle(UpdateSprintCommand request, CancellationToken cancellationToken)
    {
        var sprint = await _sprintRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Domain.Entities.Sprint), request.Id);

        sprint.Name = request.Name;
        sprint.StartDate = request.StartDate;
        sprint.EndDate = request.EndDate;

        _sprintRepository.Update(sprint);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        await _cacheService.RemoveAsync(CacheKeys.SprintsByTeam(sprint.TeamId), cancellationToken);

        return new SprintDto(sprint.Id, sprint.Name, sprint.StartDate, sprint.EndDate, sprint.TeamId, sprint.CreatedAtUtc);
    }
}
