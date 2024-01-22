#region

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tiveriad.Core.Abstractions.Entities;

#endregion

namespace DataReference.Integration.Persistence.Entities;

public class CivilityConfiguration : IEntityTypeConfiguration<Civility>
{
    public void Configure(EntityTypeBuilder<Civility> builder)
    {
        builder.ToTable("T_Civility");
        // <-- Id -->
        builder.HasKey(b => b.Id).HasName("PK_CivilityId");
        // <-- ManyToOne -->
        // <-- OneToMany -->
        // <-- Enum -->
        // <-- Object -->
        builder.Property(b => b.Label).HasConversion(v => v == null ? string.Empty : v.ToString(),
            v => string.IsNullOrEmpty(v) ? null : (InternationalizedString)v);
    }
}