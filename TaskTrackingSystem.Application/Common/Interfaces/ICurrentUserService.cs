namespace TaskTrackingSystem.Application.Common.Interfaces;

public interface ICurrentUserService
{
    Guid UserId { get; }
    bool IsAdmin { get; }
    Task<Guid?> GetTeamIdAsync(CancellationToken cancellationToken = default);
}
