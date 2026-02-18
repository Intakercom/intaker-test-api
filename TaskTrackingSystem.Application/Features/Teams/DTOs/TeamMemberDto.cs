namespace TaskTrackingSystem.Application.Features.Teams.DTOs;

public record TeamMemberDto(Guid Id, string Email, string FirstName, string LastName, string Role);
