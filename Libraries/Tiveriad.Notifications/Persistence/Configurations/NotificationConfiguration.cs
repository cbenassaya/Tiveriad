
using Microsoft.EntityFrameworkCore;
using Tiveriad.Notifications.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Tiveriad.Notifications.Persistence.Configurations;

public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{




    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.ToTable("T_Notification");
        // <-- Id -->
        builder.HasKey(b => b.Id).HasName("PK_NotificationId");
        // <-- ManyToOne -->
        builder.HasOne(b => b.Subject);
        builder.HasOne(b => b.Message);
        // <-- OneToMany -->

        // <-- Enum -->
        builder.Property(e => e.State).HasConversion(v => v.ToString(), v => (NotificationState)Enum.Parse(typeof(NotificationState), v));
        // <-- Object -->

    }
}

