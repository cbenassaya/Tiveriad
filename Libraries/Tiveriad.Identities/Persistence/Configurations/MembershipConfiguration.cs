
using Microsoft.EntityFrameworkCore;
using Tiveriad.Identities.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Tiveriad.Identities.Persistence.Configurations;

public class MembershipConfiguration : IEntityTypeConfiguration<Membership>
{




    public void Configure(EntityTypeBuilder<Membership> builder)
    {
        builder.ToTable("T_Membership");
        // <-- Id -->
        builder.HasKey(b => b.Id).HasName("PK_MembershipId");
        // <-- ManyToOne -->
        builder.HasOne(b => b.User);
        builder.HasOne(b => b.Organization);
        // <-- OneToMany -->

        // <-- Enum -->
        builder.Property(e => e.State).HasConversion(v => v.ToString(), v => (MembershipState)Enum.Parse(typeof(MembershipState), v));
        // <-- Object -->
        builder.Property(e => e.Properties).HasConversion(v => v == null ? string.Empty : v.ToString(), v => string.IsNullOrEmpty(v) ? null : (Metadata)v);
    }
}

