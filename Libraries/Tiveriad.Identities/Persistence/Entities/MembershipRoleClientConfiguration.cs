#region

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Persistence.Entities;

public class MembershipRoleClientConfiguration : IEntityTypeConfiguration<MembershipRoleClientMapping>
{
    public void Configure(EntityTypeBuilder<MembershipRoleClientMapping> builder)
    {
        builder.ToTable("T_UserRoleClientMapping");
        // <-- Id -->
        builder.HasKey(b => b.Id).HasName("PK_UserRoleClientMappingId");
        // <-- ManyToOne -->
        builder.HasOne(b => b.Membership);
        builder.HasOne(b => b.Role);
        builder.HasOne(b => b.Client);
        // <-- OneToMany -->
        // <-- Enum -->
        // <-- Object -->
    }
}