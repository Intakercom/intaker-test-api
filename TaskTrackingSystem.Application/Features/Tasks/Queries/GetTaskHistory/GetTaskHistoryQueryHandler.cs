using MediatR;
using TaskTrackingSystem.Application.Features.Tasks.DTOs;
using TaskTrackingSystem.Domain.Repositories;

namespace TaskTrackingSystem.Application.Features.Tasks.Queries.GetTaskHistory;

public class GetTaskHistoryQueryHandler : IRequestHandler<GetTaskHistoryQuery, IReadOnlyList<TaskHistoryDto>>
{
    private readonly ITaskHistoryRepository _taskHistoryRepository;

    public GetTaskHistoryQueryHandler(ITaskHistoryRepository taskHistoryRepository)
    {
        _taskHistoryRepository = taskHistoryRepository;
    }

    public async Task<IReadOnlyList<TaskHistoryDto>> Handle(GetTaskHistoryQuery request, CancellationToken cancellationToken)
    {
        var history = await _taskHistoryRepository.GetByTaskIdAsync(request.TaskId, cancellationToken);

        return history.Select(h => new TaskHistoryDto(
            h.Id,
            h.TaskId,
            h.UserId,
            $"{h.User.FirstName} {h.User.LastName}",
            h.ChangeType.ToString(),
            h.FieldName,
            h.OldValue,
            h.NewValue,
            h.CreatedAtUtc
        )).ToList();
    }
}
