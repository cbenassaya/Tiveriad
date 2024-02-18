#region

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Persistence.Configurations;

public class PolicyConfiguration : IEntityTypeConfiguration<Policy>
{
    public void Configure(EntityTypeBuilder<Policy> builder)
    {
        builder.ToTable("T_Policy");
        // <-- Id -->
        builder.HasKey(b => b.Id).HasName("PK_PolicyId");
        // <-- ManyToOne -->
        builder.HasOne(b => b.Realm);
        builder.HasOne(b => b.Role);
        builder.HasOne(b => b.Feature);
        // <-- OneToMany -->

        // <-- Enum -->

        // <-- Object -->
    }
}