using MediatR;
using TaskTrackingSystem.Application.Features.Sprints.DTOs;

namespace TaskTrackingSystem.Application.Features.Sprints.Commands.CreateSprint;

public record CreateSprintCommand(string Name, DateTime StartDate, DateTime EndDate, Guid? TeamId = null) : IRequest<SprintDto>;
