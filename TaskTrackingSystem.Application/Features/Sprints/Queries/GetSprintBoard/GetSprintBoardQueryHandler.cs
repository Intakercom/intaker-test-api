using MediatR;
using TaskTrackingSystem.Application.Common.Exceptions;
using TaskTrackingSystem.Application.Features.Sprints.DTOs;
using TaskTrackingSystem.Domain.Enums;
using TaskTrackingSystem.Domain.Repositories;

namespace TaskTrackingSystem.Application.Features.Sprints.Queries.GetSprintBoard;

public class GetSprintBoardQueryHandler : IRequestHandler<GetSprintBoardQuery, SprintBoardDto>
{
    private readonly ISprintRepository _sprintRepository;

    public GetSprintBoardQueryHandler(ISprintRepository sprintRepository)
    {
        _sprintRepository = sprintRepository;
    }

    public async Task<SprintBoardDto> Handle(GetSprintBoardQuery request, CancellationToken cancellationToken)
    {
        var sprint = await _sprintRepository.GetWithTasksAsync(request.SprintId, cancellationToken)
            ?? throw new NotFoundException(nameof(Domain.Entities.Sprint), request.SprintId);

        var tasks = sprint.Tasks;

        BoardTaskDto MapTask(Domain.Entities.SprintTask t) => new(
            t.Id,
            t.Title,
            t.AssigneeId,
            t.Assignee is not null ? $"{t.Assignee.FirstName} {t.Assignee.LastName}" : null);

        return new SprintBoardDto(
            sprint.Id,
            sprint.Name,
            ToDo: tasks.Where(t => t.Status == SprintTaskStatus.ToDo).Select(MapTask).ToList().AsReadOnly(),
            InProgress: tasks.Where(t => t.Status == SprintTaskStatus.InProgress).Select(MapTask).ToList().AsReadOnly(),
            Done: tasks.Where(t => t.Status == SprintTaskStatus.Done).Select(MapTask).ToList().AsReadOnly());
    }
}
