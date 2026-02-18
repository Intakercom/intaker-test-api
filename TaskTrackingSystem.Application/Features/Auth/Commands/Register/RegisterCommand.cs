using MediatR;
using TaskTrackingSystem.Application.Features.Auth.DTOs;

namespace TaskTrackingSystem.Application.Features.Auth.Commands.Register;

public record RegisterCommand(
    string Email,
    string Password,
    string FirstName,
    string LastName) : IRequest<AuthResponse>;
