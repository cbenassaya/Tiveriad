
using Microsoft.EntityFrameworkCore;
using Tiveriad.ReferenceData.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Tiveriad.ReferenceData.Persistence.Configurations;

public class InternationalizedValueConfiguration : IEntityTypeConfiguration<InternationalizedValue>
{




    public void Configure(EntityTypeBuilder<InternationalizedValue> builder)
    {
        builder.ToTable("T_InternationalizedValue");
        // <-- Id -->
        builder.HasKey(b => b.Id).HasName("PK_InternationalizedValueId");
        // <-- ManyToOne -->

        // <-- OneToMany -->

        // <-- ManyToMany -->

        // <-- Enum -->

        // <-- Tiveriad Object -->

        // <-- Object -->

    }
}

