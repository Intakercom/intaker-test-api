using TaskTrackingSystem.Domain.Entities;

namespace TaskTrackingSystem.Domain.Repositories;

public interface ISprintTaskRepository : IRepository<SprintTask>
{
    Task<IReadOnlyList<SprintTask>> GetBySprintIdAsync(Guid sprintId, CancellationToken cancellationToken = default);
}
