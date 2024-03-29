
using Microsoft.EntityFrameworkCore;
using Tiveriad.Identities.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Tiveriad.Identities.Persistence.Configurations;

public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
{




    public void Configure(EntityTypeBuilder<Organization> builder)
    {
        builder.ToTable("T_Organization");
        // <-- Id -->
        builder.HasKey(b => b.Id).HasName("PK_OrganizationId");
        // <-- ManyToOne -->
        builder.HasOne(b => b.Owner);
        // <-- OneToMany -->

        // <-- ManyToMany -->

        // <-- Enum -->
        builder.Property(e => e.State).HasConversion(v => v.ToString(), v => (OrganizationState)Enum.Parse(typeof(OrganizationState), v));
        // <-- Tiveriad Object -->
        builder.Property(e => e.Properties).HasConversion(v => v == null ? string.Empty : v.ToString(), v => (string.IsNullOrEmpty(v) ? null : (Metadata?)v)!);
        // <-- Object -->

    }
}

