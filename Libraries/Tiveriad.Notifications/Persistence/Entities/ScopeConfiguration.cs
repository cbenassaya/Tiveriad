#region

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tiveriad.Notifications.Core.Entities;

#endregion

namespace Tiveriad.Notifications.Persistence.Entities;

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