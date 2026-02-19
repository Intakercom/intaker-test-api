using Microsoft.EntityFrameworkCore;
using TaskTrackingSystem.Domain.Entities;

namespace TaskTrackingSystem.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Team> Teams => Set<Team>();
    public DbSet<Sprint> Sprints => Set<Sprint>();
    public DbSet<SprintTask> SprintTasks => Set<SprintTask>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        DataSeeder.Seed(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }
}
