using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskTrackingSystem.API.Middleware;
using TaskTrackingSystem.Application.Features.Teams.Commands.AddTeamMember;
using TaskTrackingSystem.Application.Features.Teams.Commands.CreateTeam;
using TaskTrackingSystem.Application.Features.Teams.DTOs;
using TaskTrackingSystem.Application.Features.Teams.Queries.GetTeamMembers;
using TaskTrackingSystem.Application.Features.Teams.Queries.GetTeams;

namespace TaskTrackingSystem.API.Controllers;

/// <summary>
/// Manage teams and team membership.
/// Admin users can create teams and manage members. Member users can view their own team.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Authorize]
[Produces("application/json")]
public class TeamsController : ControllerBase
{
    private readonly ISender _sender;

    public TeamsController(ISender sender)
    {
        _sender = sender;
    }

    /// <summary>
    /// Get teams visible to the current user.
    /// </summary>
    /// <remarks>
    /// - **Admin** users see all teams in the system.
    /// - **Member** users see only the team they belong to (or an empty list if unassigned).
    /// </remarks>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A list of teams.</returns>
    /// <response code="200">Returns the list of teams.</response>
    /// <response code="401">User is not authenticated.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<TeamDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetTeamsQuery(), cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Create a new team. Admin only.
    /// </summary>
    /// <remarks>
    /// Creates a team with the given name and optional description.
    /// Only users with the **Admin** role can create teams.
    ///
    /// Sample request:
    ///
    ///     POST /api/teams
    ///     {
    ///         "name": "Backend Team",
    ///         "description": "Handles API and infrastructure work"
    ///     }
    ///
    /// </remarks>
    /// <param name="command">Team creation details.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The newly created team.</returns>
    /// <response code="200">Team created successfully.</response>
    /// <response code="400">Validation failed (e.g. missing name).</response>
    /// <response code="401">User is not authenticated.</response>
    /// <response code="403">User does not have the Admin role.</response>
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(TeamDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Create(CreateTeamCommand command, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Get all members of a specific team.
    /// </summary>
    /// <remarks>
    /// Returns the list of users assigned to the specified team, including their role.
    /// </remarks>
    /// <param name="teamId">The unique identifier of the team.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A list of team members.</returns>
    /// <response code="200">Returns the team members.</response>
    /// <response code="401">User is not authenticated.</response>
    /// <response code="404">Team not found.</response>
    [HttpGet("{teamId:guid}/members")]
    [ProducesResponseType(typeof(IReadOnlyList<TeamMemberDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetMembers(Guid teamId, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetTeamMembersQuery(teamId), cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Add a user to a team by email. Admin only.
    /// </summary>
    /// <remarks>
    /// Assigns an existing user to the specified team.
    /// Only users with the **Admin** role can add team members.
    ///
    /// Sample request:
    ///
    ///     POST /api/teams/{teamId}/members
    ///     {
    ///         "email": "john@example.com"
    ///     }
    ///
    /// </remarks>
    /// <param name="teamId">The unique identifier of the team.</param>
    /// <param name="request">The email of the user to add.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <response code="204">User added to the team successfully.</response>
    /// <response code="400">Validation failed (e.g. missing email).</response>
    /// <response code="401">User is not authenticated.</response>
    /// <response code="403">User does not have the Admin role.</response>
    /// <response code="404">Team or user not found.</response>
    /// <response code="409">User already belongs to a team.</response>
    [HttpPost("{teamId:guid}/members")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status409Conflict)]
    public async Task<IActionResult> AddMember(Guid teamId, AddTeamMemberRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new AddTeamMemberCommand(teamId, request.Email), cancellationToken);
        return NoContent();
    }
}

/// <summary>
/// Request body for adding a team member.
/// </summary>
/// <param name="Email">The email address of the user to add to the team.</param>
public record AddTeamMemberRequest(string Email);
