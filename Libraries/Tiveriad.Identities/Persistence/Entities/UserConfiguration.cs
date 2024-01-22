#region

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Persistence.Entities;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("T_User");
        // <-- Id -->
        builder.HasKey(b => b.Id).HasName("PK_UserId");
        // <-- ManyToOne -->
        // <-- OneToMany -->
        // <-- Enum -->
        // <-- Object -->
    }
}