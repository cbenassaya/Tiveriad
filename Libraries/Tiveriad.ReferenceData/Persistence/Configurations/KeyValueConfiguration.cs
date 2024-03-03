
using Microsoft.EntityFrameworkCore;
using Tiveriad.ReferenceData.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Tiveriad.ReferenceData.Persistence.Configurations;

public class KeyValueConfiguration : IEntityTypeConfiguration<KeyValue>
{




    public void Configure(EntityTypeBuilder<KeyValue> builder)
    {
        builder.ToTable("T_KeyValue");
        // <-- Id -->
        builder.HasKey(b => b.Id).HasName("PK_KeyValueId");
        // <-- ManyToOne -->

        // <-- OneToMany -->
        builder.HasMany(b => b.InternationalizedValues);
        // <-- ManyToMany -->

        // <-- Enum -->

        // <-- Tiveriad Object -->
        builder.Property(e => e.Properties).HasConversion(v => v == null ? string.Empty : v.ToString(), v => (string.IsNullOrEmpty(v) ? null : (Metadata?)v)!);
        builder.Property(e => e.Visibility).HasConversion(v => v == null ? string.Empty : v.ToString(), v => (string.IsNullOrEmpty(v) ? null : (Visibility)v)!);
        // <-- Object -->

    }
}

