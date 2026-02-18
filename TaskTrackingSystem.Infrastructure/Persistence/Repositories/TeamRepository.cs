using Microsoft.EntityFrameworkCore;
using TaskTrackingSystem.Domain.Entities;
using TaskTrackingSystem.Domain.Repositories;

namespace TaskTrackingSystem.Infrastructure.Persistence.Repositories;

public class TeamRepository : Repository<Team>, ITeamRepository
{
    public TeamRepository(ApplicationDbContext context) : base(context) { }

    public async Task<Team?> GetWithMembersAsync(Guid teamId, CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Include(t => t.Members)
            .FirstOrDefaultAsync(t => t.Id == teamId, cancellationToken);
    }
}
