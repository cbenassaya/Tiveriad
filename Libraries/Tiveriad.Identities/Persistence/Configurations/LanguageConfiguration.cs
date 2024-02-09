
using Microsoft.EntityFrameworkCore;
using Tiveriad.Identities.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Tiveriad.Identities.Persistence.Configurations;

public class LanguageConfiguration : IEntityTypeConfiguration<Language>
{




    public void Configure(EntityTypeBuilder<Language> builder)
    {
        builder.ToTable("T_Language");
        // <-- Id -->
        builder.HasKey(b => b.Id).HasName("PK_LanguageId");
        // <-- ManyToOne -->

        // <-- OneToMany -->

        // <-- Enum -->

        // <-- Object -->

    }
}

