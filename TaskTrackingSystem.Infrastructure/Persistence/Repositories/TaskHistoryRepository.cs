using Microsoft.EntityFrameworkCore;
using TaskTrackingSystem.Domain.Entities;
using TaskTrackingSystem.Domain.Repositories;

namespace TaskTrackingSystem.Infrastructure.Persistence.Repositories;

public class TaskHistoryRepository : ITaskHistoryRepository
{
    private readonly ApplicationDbContext _context;

    public TaskHistoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<TaskHistory>> GetByTaskIdAsync(Guid taskId, CancellationToken cancellationToken = default)
    {
        return await _context.TaskHistories
            .Where(h => h.TaskId == taskId)
            .Include(h => h.User)
            .OrderByDescending(h => h.CreatedAtUtc)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(TaskHistory entity, CancellationToken cancellationToken = default)
    {
        await _context.TaskHistories.AddAsync(entity, cancellationToken);
    }
}
