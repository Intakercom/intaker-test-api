using TaskTrackingSystem.Domain.Entities;

namespace TaskTrackingSystem.Domain.Repositories;

public interface ISprintRepository : IRepository<Sprint>
{
    Task<IReadOnlyList<Sprint>> GetByTeamIdAsync(Guid teamId, CancellationToken cancellationToken = default);
    Task<Sprint?> GetWithTasksAsync(Guid sprintId, CancellationToken cancellationToken = default);
}
