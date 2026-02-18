using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using TaskTrackingSystem.Application.Common.Interfaces;
using TaskTrackingSystem.Domain.Repositories;

namespace TaskTrackingSystem.Infrastructure.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUserRepository _userRepository;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository)
    {
        _httpContextAccessor = httpContextAccessor;
        _userRepository = userRepository;
    }

    public Guid UserId
    {
        get
        {
            var sub = _httpContextAccessor.HttpContext?.User.FindFirstValue(JwtRegisteredClaimNames.Sub)
                      ?? _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Guid.TryParse(sub, out var userId) ? userId : Guid.Empty;
        }
    }

    public bool IsAdmin
    {
        get
        {
            var role = _httpContextAccessor.HttpContext?.User.FindFirstValue("role");
            return string.Equals(role, "Admin", StringComparison.OrdinalIgnoreCase);
        }
    }

    public async Task<Guid?> GetTeamIdAsync(CancellationToken cancellationToken = default)
    {
        if (UserId == Guid.Empty)
            return null;

        var user = await _userRepository.GetByIdAsync(UserId, cancellationToken);
        return user?.TeamId;
    }
}
