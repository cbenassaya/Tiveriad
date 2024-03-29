
using Microsoft.EntityFrameworkCore;
using Tiveriad.Identities.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Tiveriad.Identities.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{




    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("T_User");
        // <-- Id -->
        builder.HasKey(b => b.Id).HasName("PK_UserId");
        // <-- ManyToOne -->

        // <-- OneToMany -->

        // <-- ManyToMany -->

        // <-- Enum -->

        // <-- Tiveriad Object -->
        builder.Property(e => e.Properties).HasConversion(v => v == null ? string.Empty : v.ToString(), v => (string.IsNullOrEmpty(v) ? null : (Metadata?)v)!);
        // <-- Object -->

    }
}

