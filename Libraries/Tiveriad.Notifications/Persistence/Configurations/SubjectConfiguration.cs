
using Microsoft.EntityFrameworkCore;
using Tiveriad.Notifications.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Tiveriad.Notifications.Persistence.Configurations;

public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{




    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.ToTable("T_Subject");
        // <-- Id -->
        builder.HasKey(b => b.Id).HasName("PK_SubjectId");
        // <-- ManyToOne -->
        builder.HasOne(b => b.Template);
        // <-- OneToMany -->
        builder.HasMany(b => b.Scopes);
        // <-- Enum -->
        builder.Property(e => e.State).HasConversion(v => v.ToString(), v => (SubjectState)Enum.Parse(typeof(SubjectState), v));
        // <-- Object -->
        builder.Property(e => e.Description).HasConversion(v => v == null ? string.Empty : v.ToString(), v => string.IsNullOrEmpty(v) ? null : (InternationalizedString)v);
    }
}

