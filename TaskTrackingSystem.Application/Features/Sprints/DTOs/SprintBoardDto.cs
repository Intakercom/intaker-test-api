namespace TaskTrackingSystem.Application.Features.Sprints.DTOs;

public record SprintBoardDto(
    Guid SprintId,
    string SprintName,
    IReadOnlyList<BoardTaskDto> ToDo,
    IReadOnlyList<BoardTaskDto> InProgress,
    IReadOnlyList<BoardTaskDto> Done);

public record BoardTaskDto(
    Guid Id,
    string Title,
    Guid? AssigneeId,
    string? AssigneeName);
