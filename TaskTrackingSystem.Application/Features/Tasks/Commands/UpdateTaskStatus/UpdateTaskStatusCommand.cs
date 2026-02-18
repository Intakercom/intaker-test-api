using MediatR;
using TaskTrackingSystem.Domain.Enums;

namespace TaskTrackingSystem.Application.Features.Tasks.Commands.UpdateTaskStatus;

public record UpdateTaskStatusCommand(Guid Id, SprintTaskStatus Status) : IRequest<Unit>;
