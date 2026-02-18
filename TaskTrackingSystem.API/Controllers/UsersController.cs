using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskTrackingSystem.Application.Features.Users.DTOs;
using TaskTrackingSystem.Application.Features.Users.Queries.GetUsers;

namespace TaskTrackingSystem.API.Controllers;

/// <summary>
/// User management endpoints. Admin only.
/// Provides read access to all user accounts in the system.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin")]
[Produces("application/json")]
public class UsersController : ControllerBase
{
    private readonly ISender _sender;

    public UsersController(ISender sender)
    {
        _sender = sender;
    }

    /// <summary>
    /// Get all users in the system. Admin only.
    /// </summary>
    /// <remarks>
    /// Returns all registered users with their profile details, role, and team assignment.
    /// Useful for admin dashboards and user assignment workflows (e.g. adding members to teams, assigning tasks).
    ///
    /// Sensitive fields such as password hashes are never included in the response.
    /// </remarks>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A list of all users.</returns>
    /// <response code="200">Returns all users.</response>
    /// <response code="401">User is not authenticated.</response>
    /// <response code="403">User does not have the Admin role.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<UserDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetUsersQuery(), cancellationToken);
        return Ok(result);
    }
}
