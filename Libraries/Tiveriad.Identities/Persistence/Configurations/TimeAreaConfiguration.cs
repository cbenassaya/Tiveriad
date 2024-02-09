
using Microsoft.EntityFrameworkCore;
using Tiveriad.Identities.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Tiveriad.Identities.Persistence.Configurations;

public class TimeAreaConfiguration : IEntityTypeConfiguration<TimeArea>
{




    public void Configure(EntityTypeBuilder<TimeArea> builder)
    {
        builder.ToTable("T_TimeArea");
        // <-- Id -->
        builder.HasKey(b => b.Id).HasName("PK_TimeAreaId");
        // <-- ManyToOne -->

        // <-- OneToMany -->

        // <-- Enum -->

        // <-- Object -->

    }
}

