namespace TaskTrackingSystem.Application.Features.Tasks.DTOs;

public record TaskDto(
    Guid Id,
    string Title,
    string? Description,
    string Status,
    Guid? AssigneeId,
    string? AssigneeName,
    Guid SprintId,
    Guid CreatedByUserId,
    DateTime CreatedAtUtc,
    DateTime? UpdatedAtUtc);
