using MediatR;
using TaskTrackingSystem.Application.Features.Tasks.DTOs;

namespace TaskTrackingSystem.Application.Features.Tasks.Commands.CreateTask;

public record CreateTaskCommand(string Title, string? Description, Guid? AssigneeId, Guid SprintId) : IRequest<TaskDto>;
