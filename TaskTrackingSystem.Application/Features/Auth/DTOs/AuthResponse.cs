namespace TaskTrackingSystem.Application.Features.Auth.DTOs;

public record AuthResponse(string Token, Guid UserId, string Email, string Role);
