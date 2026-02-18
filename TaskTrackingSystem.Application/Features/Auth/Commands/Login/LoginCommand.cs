using MediatR;
using TaskTrackingSystem.Application.Features.Auth.DTOs;

namespace TaskTrackingSystem.Application.Features.Auth.Commands.Login;

public record LoginCommand(string Email, string Password) : IRequest<AuthResponse>;
