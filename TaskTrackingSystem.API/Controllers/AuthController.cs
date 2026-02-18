using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskTrackingSystem.API.Middleware;
using TaskTrackingSystem.Application.Features.Auth.Commands.Login;
using TaskTrackingSystem.Application.Features.Auth.Commands.Register;
using TaskTrackingSystem.Application.Features.Auth.DTOs;

namespace TaskTrackingSystem.API.Controllers;

/// <summary>
/// Handles user registration and authentication.
/// These endpoints are public and do not require a JWT token.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class AuthController : ControllerBase
{
    private readonly ISender _sender;

    public AuthController(ISender sender)
    {
        _sender = sender;
    }

    /// <summary>
    /// Register a new user account.
    /// </summary>
    /// <remarks>
    /// Creates a new user with the **Member** role and returns a JWT token.
    /// The user is not assigned to any team by default — an Admin must add them via the Teams endpoint.
    ///
    /// Sample request:
    ///
    ///     POST /api/auth/register
    ///     {
    ///         "email": "john@example.com",
    ///         "password": "SecurePass123!",
    ///         "firstName": "John",
    ///         "lastName": "Doe"
    ///     }
    ///
    /// </remarks>
    /// <param name="command">User registration details.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A JWT token, user information, and assigned role.</returns>
    /// <response code="200">User registered successfully. Returns JWT token, user ID, email, and role.</response>
    /// <response code="400">Validation failed (e.g. invalid email, weak password).</response>
    /// <response code="409">A user with this email already exists.</response>
    [HttpPost("register")]
    [ProducesResponseType(typeof(AuthResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status409Conflict)]
    public async Task<IActionResult> Register(RegisterCommand command, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Authenticate and obtain a JWT token.
    /// </summary>
    /// <remarks>
    /// Validates credentials and returns a JWT token on success.
    /// Include the token in subsequent requests as: `Authorization: Bearer {token}`
    ///
    /// The token contains the following claims: `sub` (user ID), `email`, `role` (Admin/Member), `jti` (unique token ID).
    /// Token expiration is configured server-side (default: 24 hours).
    ///
    /// Sample request:
    ///
    ///     POST /api/auth/login
    ///     {
    ///         "email": "john@example.com",
    ///         "password": "SecurePass123!"
    ///     }
    ///
    /// </remarks>
    /// <param name="command">Login credentials.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A JWT token, user information, and assigned role.</returns>
    /// <response code="200">Authentication successful. Returns JWT token, user ID, email, and role.</response>
    /// <response code="400">Validation failed (e.g. empty email or password).</response>
    /// <response code="401">Invalid email or password.</response>
    [HttpPost("login")]
    [ProducesResponseType(typeof(AuthResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Login(LoginCommand command, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(command, cancellationToken);
        return Ok(result);
    }
}
