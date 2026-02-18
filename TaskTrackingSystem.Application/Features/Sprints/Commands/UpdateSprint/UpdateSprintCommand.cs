using MediatR;
using TaskTrackingSystem.Application.Features.Sprints.DTOs;

namespace TaskTrackingSystem.Application.Features.Sprints.Commands.UpdateSprint;

public record UpdateSprintCommand(Guid Id, string Name, DateTime StartDate, DateTime EndDate) : IRequest<SprintDto>;
