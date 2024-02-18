#region

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Persistence.Configurations;

public class RealmConfiguration : IEntityTypeConfiguration<Realm>
{
    public void Configure(EntityTypeBuilder<Realm> builder)
    {
        builder.ToTable("T_Realm");
        // <-- Id -->
        builder.HasKey(b => b.Id).HasName("PK_RealmId");
        // <-- ManyToOne -->

        // <-- OneToMany -->
        builder.HasMany(b => b.Features);
        // <-- Enum -->

        // <-- Object -->
        builder.Property(e => e.Properties).HasConversion(v => v == null ? string.Empty : v.ToString(),
            v => string.IsNullOrEmpty(v) ? null : (Metadata)v);
    }
}