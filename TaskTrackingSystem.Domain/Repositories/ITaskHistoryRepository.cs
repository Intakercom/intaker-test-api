using TaskTrackingSystem.Domain.Entities;

namespace TaskTrackingSystem.Domain.Repositories;

public interface ITaskHistoryRepository
{
    Task<IReadOnlyList<TaskHistory>> GetByTaskIdAsync(Guid taskId, CancellationToken cancellationToken = default);
    Task AddAsync(TaskHistory entity, CancellationToken cancellationToken = default);
}
