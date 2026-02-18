using TaskTrackingSystem.Domain.Common;
using TaskTrackingSystem.Domain.Enums;

namespace TaskTrackingSystem.Domain.Entities;

public class User : BaseEntity
{
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public TeamRole Role { get; set; } = TeamRole.Member;

    public Guid? TeamId { get; set; }
    public Team? Team { get; set; }

    public ICollection<SprintTask> AssignedTasks { get; set; } = new List<SprintTask>();
    public ICollection<SprintTask> CreatedTasks { get; set; } = new List<SprintTask>();
}
