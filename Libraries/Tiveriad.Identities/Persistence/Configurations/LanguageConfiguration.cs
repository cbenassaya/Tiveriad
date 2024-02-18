#region

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tiveriad.Identities.Core.Entities;

#endregion

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