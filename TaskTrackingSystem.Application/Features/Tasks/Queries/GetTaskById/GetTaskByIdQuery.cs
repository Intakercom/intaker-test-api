using MediatR;
using TaskTrackingSystem.Application.Features.Tasks.DTOs;

namespace TaskTrackingSystem.Application.Features.Tasks.Queries.GetTaskById;

public record GetTaskByIdQuery(Guid Id) : IRequest<TaskDto>;
