namespace TaskTrackingSystem.Application.Features.Sprints.DTOs;

public record SprintDto(Guid Id, string Name, DateTime StartDate, DateTime EndDate, Guid TeamId, DateTime CreatedAtUtc);
