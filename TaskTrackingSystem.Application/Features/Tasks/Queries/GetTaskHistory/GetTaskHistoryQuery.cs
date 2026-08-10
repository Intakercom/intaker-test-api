using MediatR;
using TaskTrackingSystem.Application.Features.Tasks.DTOs;

namespace TaskTrackingSystem.Application.Features.Tasks.Queries.GetTaskHistory;

public record GetTaskHistoryQuery(Guid TaskId) : IRequest<IReadOnlyList<TaskHistoryDto>>;
