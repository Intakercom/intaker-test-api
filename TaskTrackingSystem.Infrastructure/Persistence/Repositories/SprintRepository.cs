using Microsoft.EntityFrameworkCore;
using TaskTrackingSystem.Domain.Entities;
using TaskTrackingSystem.Domain.Repositories;

namespace TaskTrackingSystem.Infrastructure.Persistence.Repositories;

public class SprintRepository : Repository<Sprint>, ISprintRepository
{
    public SprintRepository(ApplicationDbContext context) : base(context) { }

    public override async Task<IReadOnlyList<Sprint>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Include(s => s.Tasks)
            .Include(s => s.Team)
            .OrderBy(s => s.StartDate)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Sprint>> GetByTeamIdAsync(Guid teamId, CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Include(s => s.Tasks)
            .Include(s => s.Team)
            .Where(s => s.TeamId == teamId)
            .OrderBy(s => s.StartDate)
            .ToListAsync(cancellationToken);
    }

    public async Task<Sprint?> GetWithTasksAsync(Guid sprintId, CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Include(s => s.Tasks)
                .ThenInclude(t => t.Assignee)
            .FirstOrDefaultAsync(s => s.Id == sprintId, cancellationToken);
    }
}
