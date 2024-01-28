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
        builder.Navigation(b => b.Template).IsRequired();
        // <-- OneToMany -->
        builder.HasMany(b => b.Scopes);
        // <-- Enum -->
        builder.Property(e => e.State)
            .HasConversion(v => v.ToString(), v => (SubjectState)Enum.Parse(typeof(SubjectState), v));
        // <-- Object -->
        builder.Property(e => e.Description).HasConversion(v => v == null ? string.Empty : v.ToString(),
            v => string.IsNullOrEmpty(v) ? null : (InternationalizedString)v);
    }
}