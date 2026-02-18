using MediatR;
using TaskTrackingSystem.Application.Features.Tasks.DTOs;

namespace TaskTrackingSystem.Application.Features.Tasks.Commands.UpdateTask;

public record UpdateTaskCommand(Guid Id, string Title, string? Description, Guid? AssigneeId) : IRequest<TaskDto>;
