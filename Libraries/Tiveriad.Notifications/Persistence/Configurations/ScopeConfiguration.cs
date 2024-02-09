
using Microsoft.EntityFrameworkCore;
using Tiveriad.Notifications.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Tiveriad.Notifications.Persistence.Configurations;

public class ScopeConfiguration : IEntityTypeConfiguration<Scope>
{




    public void Configure(EntityTypeBuilder<Scope> builder)
    {
        builder.ToTable("T_Scope");
        // <-- Id -->
        builder.HasKey(b => b.Id).HasName("PK_ScopeId");
        // <-- ManyToOne -->

        // <-- OneToMany -->

        // <-- Enum -->

        // <-- Object -->

    }
}

