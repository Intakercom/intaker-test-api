using MediatR;
using TaskTrackingSystem.Application.Features.Sprints.DTOs;

namespace TaskTrackingSystem.Application.Features.Sprints.Queries.GetSprintBoard;

public record GetSprintBoardQuery(Guid SprintId) : IRequest<SprintBoardDto>;
