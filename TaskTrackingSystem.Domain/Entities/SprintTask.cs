using TaskTrackingSystem.Domain.Common;
using TaskTrackingSystem.Domain.Enums;

namespace TaskTrackingSystem.Domain.Entities;

public class SprintTask : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public SprintTaskStatus Status { get; set; } = SprintTaskStatus.ToDo;

    public Guid? AssigneeId { get; set; }
    public User? Assignee { get; set; }

    public Guid SprintId { get; set; }
    public Sprint Sprint { get; set; } = null!;

    public Guid CreatedByUserId { get; set; }
    public User CreatedByUser { get; set; } = null!;
}
