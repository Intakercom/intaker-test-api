namespace TaskTrackingSystem.Application.Features.Teams.DTOs;

public record TeamDto(Guid Id, string Name, string? Description, DateTime CreatedAtUtc);
