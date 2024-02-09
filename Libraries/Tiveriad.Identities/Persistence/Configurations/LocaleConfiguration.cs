
using Microsoft.EntityFrameworkCore;
using Tiveriad.Identities.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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

