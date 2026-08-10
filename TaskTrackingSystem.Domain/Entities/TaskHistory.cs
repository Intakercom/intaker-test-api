using TaskTrackingSystem.Domain.Enums;

namespace TaskTrackingSystem.Domain.Entities;

public class TaskHistory
{
    public Guid Id { get; set; }
    public Guid TaskId { get; set; }
    public Guid UserId { get; set; }
    public TaskChangeType ChangeType { get; set; }
    public string? FieldName { get; set; }
    public string? OldValue { get; set; }
    public string? NewValue { get; set; }
    public DateTime CreatedAtUtc { get; set; }

    // Navigation properties
    public SprintTask Task { get; set; } = null!;
    public User User { get; set; } = null!;
}
