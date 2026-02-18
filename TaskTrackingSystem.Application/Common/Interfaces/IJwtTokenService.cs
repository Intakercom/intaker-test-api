using TaskTrackingSystem.Domain.Entities;

namespace TaskTrackingSystem.Application.Common.Interfaces;

public interface IJwtTokenService
{
    string GenerateToken(User user);
}
