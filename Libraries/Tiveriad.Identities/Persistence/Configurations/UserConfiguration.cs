#region

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("T_User");
        // <-- Id -->
        builder.HasKey(b => b.Id).HasName("PK_UserId");
        // <-- ManyToOne -->
        builder.HasOne(b => b.Language);
        builder.HasOne(b => b.Locale);
        // <-- OneToMany -->

        // <-- Enum -->

        // <-- Object -->
        builder.Property(e => e.Properties).HasConversion(v => v == null ? string.Empty : v.ToString(),
            v => string.IsNullOrEmpty(v) ? null : (Metadata)v);
    }
}