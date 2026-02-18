using TaskTrackingSystem.Domain.Common;

namespace TaskTrackingSystem.Domain.Entities;

public class Sprint : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public Guid TeamId { get; set; }
    public Team Team { get; set; } = null!;

    public ICollection<SprintTask> Tasks { get; set; } = new List<SprintTask>();
}
