using MediatR;
using TaskTrackingSystem.Application.Features.Sprints.DTOs;

namespace TaskTrackingSystem.Application.Features.Sprints.Queries.GetSprints;

public record GetSprintsQuery() : IRequest<IReadOnlyList<SprintListDto>>;
