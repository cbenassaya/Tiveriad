#region

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tiveriad.Identities.Core.Entities;

#endregion

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