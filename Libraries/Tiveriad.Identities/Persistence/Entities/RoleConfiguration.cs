#region

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Persistence.Entities;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("T_Role");
        // <-- Id -->
        builder.HasKey(b => b.Id).HasName("PK_RoleId");
        // <-- ManyToOne -->
        // <-- OneToMany -->
        builder.Navigation<Client>(m => m.Client).IsRequired();
        // <-- Enum -->

        // <-- Object -->
    }
}