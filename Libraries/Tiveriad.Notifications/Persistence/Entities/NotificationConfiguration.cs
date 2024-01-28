#region

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tiveriad.Notifications.Core.Entities;

#endregion

namespace Tiveriad.Notifications.Persistence.Entities;

public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.ToTable("T_Notification");
        // <-- Id -->
        builder.HasKey(b => b.Id).HasName("PK_NotificationId");
        // <-- ManyToOne -->
        builder.Navigation(b => b.Subject).IsRequired();
        builder.Navigation(b => b.Message).IsRequired();
        // <-- OneToMany -->

        // <-- Enum -->
        builder.Property(e => e.State).HasConversion(v => v.ToString(),
            v => (NotificationState)Enum.Parse(typeof(NotificationState), v));
        // <-- Object -->
    }
}