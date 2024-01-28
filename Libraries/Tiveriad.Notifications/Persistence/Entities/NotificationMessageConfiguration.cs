#region

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Notifications.Core.Entities;

#endregion

namespace Tiveriad.Notifications.Persistence.Entities;

public class NotificationMessageConfiguration : IEntityTypeConfiguration<NotificationMessage>
{
    public void Configure(EntityTypeBuilder<NotificationMessage> builder)
    {
        builder.ToTable("T_NotificationMessage");
        // <-- Id -->
        builder.HasKey(b => b.Id).HasName("PK_NotificationMessageId");
        // <-- ManyToOne -->

        // <-- OneToMany -->

        // <-- Enum -->
        builder.Property(e => e.ConfirmMode)
            .HasConversion(v => v.ToString(), v => (ConfirmMode)Enum.Parse(typeof(ConfirmMode), v));
        // <-- Object -->
        builder.Property(e => e.Title).HasConversion(v => v == null ? string.Empty : v.ToString(),
            v => string.IsNullOrEmpty(v) ? null : (InternationalizedString)v);
        builder.Property(e => e.Body).HasConversion(v => v == null ? string.Empty : v.ToString(),
            v => string.IsNullOrEmpty(v) ? null : (InternationalizedString)v);
        builder.Property(e => e.ConfirmLink).HasConversion(v => v == null ? string.Empty : v.ToString(),
            v => string.IsNullOrEmpty(v) ? null : (InternationalizedString)v);
        builder.Property(e => e.ConfirmText).HasConversion(v => v == null ? string.Empty : v.ToString(),
            v => string.IsNullOrEmpty(v) ? null : (InternationalizedString)v);
        builder.Property(e => e.ImageSmall).HasConversion(v => v == null ? string.Empty : v.ToString(),
            v => string.IsNullOrEmpty(v) ? null : (InternationalizedString)v);
        builder.Property(e => e.ImageLarge).HasConversion(v => v == null ? string.Empty : v.ToString(),
            v => string.IsNullOrEmpty(v) ? null : (InternationalizedString)v);
        builder.Property(e => e.LinkUrl).HasConversion(v => v == null ? string.Empty : v.ToString(),
            v => string.IsNullOrEmpty(v) ? null : (InternationalizedString)v);
        builder.Property(e => e.LinkText).HasConversion(v => v == null ? string.Empty : v.ToString(),
            v => string.IsNullOrEmpty(v) ? null : (InternationalizedString)v);
    }
}