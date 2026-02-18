namespace TaskTrackingSystem.Application.Features.Users.DTOs;

public record UserDto(
    Guid Id,
    string Email,
    string FirstName,
    string LastName,
    string Role,
    Guid? TeamId,
    DateTime CreatedAtUtc);
