
using Microsoft.EntityFrameworkCore;
using Tiveriad.Registrations.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Tiveriad.Registrations.Persistence.Configurations;

public class RegistrationConfiguration : IEntityTypeConfiguration<Registration>
{




    public void Configure(EntityTypeBuilder<Registration> builder)
    {
        builder.ToTable("T_Registration");
        // <-- Id -->
        builder.HasKey(b => b.Id).HasName("PK_RegistrationId");
        // <-- ManyToOne -->
        builder.HasOne(b => b.RegistrationModel);
        // <-- OneToMany -->

        // <-- Enum -->

        // <-- Object -->
        builder.Property(e => e.Data).HasConversion(v => v == null ? string.Empty : v.ToString(), v => string.IsNullOrEmpty(v) ? null : (Metadata)v);
    }
}

