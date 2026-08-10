namespace TaskTrackingSystem.Application.Features.Tasks.DTOs;

public record TaskHistoryDto(
    Guid Id,
    Guid TaskId,
    Guid UserId,
    string UserName,
    string ChangeType,
    string? FieldName,
    string? OldValue,
    string? NewValue,
    DateTime CreatedAtUtc);
