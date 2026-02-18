using Microsoft.EntityFrameworkCore;
using TaskTrackingSystem.Domain.Entities;
using TaskTrackingSystem.Domain.Repositories;

namespace TaskTrackingSystem.Infrastructure.Persistence.Repositories;

public class SprintTaskRepository : Repository<SprintTask>, ISprintTaskRepository
{
    public SprintTaskRepository(ApplicationDbContext context) : base(context) { }

    public async Task<IReadOnlyList<SprintTask>> GetBySprintIdAsync(Guid sprintId, CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Where(t => t.SprintId == sprintId)
            .Include(t => t.Assignee)
            .ToListAsync(cancellationToken);
    }
}
