#region

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Persistence.Entities;

public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
{
    public void Configure(EntityTypeBuilder<Organization> builder)
    {
        builder.ToTable("T_Organization");
        // <-- Id -->
        builder.HasKey(b => b.Id).HasName("PK_OrganizationId");
        // <-- ManyToOne -->
        // <-- OneToMany -->
        // <-- Enum -->
        builder.Property(e => e.State).HasConversion(v => v.ToString(),
            v => (OrganizationState)Enum.Parse(typeof(OrganizationState), v));
        // <-- Object -->
    }
}