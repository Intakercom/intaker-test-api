using TaskTrackingSystem.Domain.Entities;

namespace TaskTrackingSystem.Domain.Repositories;

public interface ITeamRepository : IRepository<Team>
{
    Task<Team?> GetWithMembersAsync(Guid teamId, CancellationToken cancellationToken = default);
}
