namespace TaskTrackingSystem.Application.Features.Sprints.DTOs;

public record SprintListDto(
    Guid Id,
    string Name,
    DateTime StartDate,
    DateTime EndDate,
    bool IsActive,
    int TaskCount,
    Guid TeamId,
    string TeamName);
