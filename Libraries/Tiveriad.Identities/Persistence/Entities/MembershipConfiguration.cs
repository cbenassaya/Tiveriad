#region

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Persistence.Entities;

public class MembershipConfiguration : IEntityTypeConfiguration<Membership>
{
    public void Configure(EntityTypeBuilder<Membership> builder)
    {
        builder.ToTable("T_Membership");
        // <-- Id -->
        builder.HasKey(b => b.Id).HasName("PK_MembershipId");
        // <-- ManyToOne -->
        builder.Navigation(b => b.User).IsRequired();
        builder.Navigation(b => b.Organization).IsRequired();
        builder.Navigation(b => b.Client).IsRequired();
        // <-- OneToMany -->
        // <-- Enum -->
        builder.Property(e => e.State)
            .HasConversion(v => v.ToString(), v => (MembershipState)Enum.Parse(typeof(MembershipState), v));
        // <-- Object -->
    }
}