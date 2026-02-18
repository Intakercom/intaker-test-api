using TaskTrackingSystem.Domain.Common;

namespace TaskTrackingSystem.Domain.Entities;

public class Team : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }

    public ICollection<User> Members { get; set; } = new List<User>();
    public ICollection<Sprint> Sprints { get; set; } = new List<Sprint>();
}
