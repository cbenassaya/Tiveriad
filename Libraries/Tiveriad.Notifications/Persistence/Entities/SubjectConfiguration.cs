#region

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Notifications.Core.Entities;

#endregion

namespace Tiveriad.Notifications.Persistence.Entities;

public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.ToTable("T_Subject");

        // <-- Id -->
        builder.HasKey(b => b.Id).HasName("PK_SubjectId");
        // <-- ManyToOne -->
        builder.Navigation(x => x.Template).IsRequired();
        // <-- OneToMany -->
        builder.HasMany<Scope>(x => x.Scopes).WithOne(x => x.Subject);
        // <-- Enum -->
        builder.Property(b => b.State).HasConversion(v => v.ToString(),
            v => string.IsNullOrEmpty(v) ? SubjectState.Pending : Enum.Parse<SubjectState>(v));
        // <-- Object -->
        builder.Property(b => b.Description).HasConversion(v => v == null ? string.Empty : v.ToString(),
            v => string.IsNullOrEmpty(v) ? null : (InternationalizedString)v);
    }
}

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
        builder.Property(b => b.ConfirmMode).HasConversion(v => v.ToString(),
            v => string.IsNullOrEmpty(v) ? ConfirmMode.None : Enum.Parse<ConfirmMode>(v));
        // <-- Object -->
        builder.Property(b => b.Subject).HasConversion(v => v == null ? string.Empty : v.ToString(),
            v => string.IsNullOrEmpty(v) ? new InternationalizedString() : v);
        builder.Property(b => b.Body).HasConversion(v => v == null ? string.Empty : v.ToString(),
            v => string.IsNullOrEmpty(v) ? null : (InternationalizedString)v);
        builder.Property(b => b.ConfirmLink).HasConversion(v => v == null ? string.Empty : v.ToString(),
            v => string.IsNullOrEmpty(v) ? null : (InternationalizedString)v);
        builder.Property(b => b.ConfirmText).HasConversion(v => v == null ? string.Empty : v.ToString(),
            v => string.IsNullOrEmpty(v) ? null : (InternationalizedString)v);
        builder.Property(b => b.ImageSmall).HasConversion(v => v == null ? string.Empty : v.ToString(),
            v => string.IsNullOrEmpty(v) ? null : (InternationalizedString)v);
        builder.Property(b => b.ImageLarge).HasConversion(v => v == null ? string.Empty : v.ToString(),
            v => string.IsNullOrEmpty(v) ? null : (InternationalizedString)v);
        builder.Property(b => b.LinkUrl).HasConversion(v => v == null ? string.Empty : v.ToString(),
            v => string.IsNullOrEmpty(v) ? null : (InternationalizedString)v);
        builder.Property(b => b.LinkText).HasConversion(v => v == null ? string.Empty : v.ToString(),
            v => string.IsNullOrEmpty(v) ? null : (InternationalizedString)v);
    }
}

public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.ToTable("T_Notification");
        // <-- Id -->
        builder.HasKey(b => b.Id).HasName("PK_NotificationId");
        // <-- ManyToOne -->
        builder.Navigation(x => x.Subject).IsRequired();
        builder.Navigation(x => x.Message).IsRequired();
        // <-- OneToMany -->
        // <-- Enum -->
        builder.Property(b => b.State).HasConversion(v => v.ToString(),
            v => string.IsNullOrEmpty(v) ? NotificationState.New : Enum.Parse<NotificationState>(v));
        // <-- Object -->
    }
}