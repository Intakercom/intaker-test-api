namespace TaskTrackingSystem.Application.Features.Sprints.DTOs;

public record SprintBoardDto(
    Guid SprintId,
    string SprintName,
    IReadOnlyList<BoardTaskDto> ToDo,
    IReadOnlyList<BoardTaskDto> InProgress,
    IReadOnlyList<BoardTaskDto> Done,
    int TotalStoryPoints,
    int CompletedStoryPoints);

public record BoardTaskDto(
    Guid Id,
    string Title,
    int? StoryPoints,
    Guid? AssigneeId,
    string? AssigneeName);
