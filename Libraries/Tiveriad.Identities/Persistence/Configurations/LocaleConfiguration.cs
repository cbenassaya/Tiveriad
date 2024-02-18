#region

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Persistence.Configurations;

public class LocaleConfiguration : IEntityTypeConfiguration<Locale>
{
    public void Configure(EntityTypeBuilder<Locale> builder)
    {
        builder.ToTable("T_Locale");
        // <-- Id -->
        builder.HasKey(b => b.Id).HasName("PK_LocaleId");
        // <-- ManyToOne -->

        // <-- OneToMany -->

        // <-- Enum -->

        // <-- Object -->
    }
}