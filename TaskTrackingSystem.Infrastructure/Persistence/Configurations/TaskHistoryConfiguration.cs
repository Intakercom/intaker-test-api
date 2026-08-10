using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskTrackingSystem.Domain.Entities;

namespace TaskTrackingSystem.Infrastructure.Persistence.Configurations;

public class TaskHistoryConfiguration : IEntityTypeConfiguration<TaskHistory>
{
    public void Configure(EntityTypeBuilder<TaskHistory> builder)
    {
        builder.HasKey(h => h.Id);

        builder.Property(h => h.ChangeType)
            .HasConversion<string>()
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(h => h.FieldName)
            .HasMaxLength(100);

        builder.Property(h => h.OldValue)
            .HasMaxLength(4000);

        builder.Property(h => h.NewValue)
            .HasMaxLength(4000);

        builder.Property(h => h.CreatedAtUtc)
            .IsRequired();

        builder.HasOne(h => h.Task)
            .WithMany(t => t.History)
            .HasForeignKey(h => h.TaskId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(h => h.User)
            .WithMany()
            .HasForeignKey(h => h.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasIndex(h => new { h.TaskId, h.CreatedAtUtc })
            .IsDescending(false, true);
    }
}
