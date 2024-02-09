
using Microsoft.EntityFrameworkCore;
using Tiveriad.Registrations.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Tiveriad.Registrations.Persistence.Configurations;

public class RegistrationModelConfiguration : IEntityTypeConfiguration<RegistrationModel>
{




    public void Configure(EntityTypeBuilder<RegistrationModel> builder)
    {
        builder.ToTable("T_RegistrationModel");
        // <-- Id -->
        builder.HasKey(b => b.Id).HasName("PK_RegistrationModelId");
        // <-- ManyToOne -->

        // <-- OneToMany -->

        // <-- Enum -->

        // <-- Object -->
        builder.Property(e => e.Model).HasConversion(v => v == null ? string.Empty : v.ToString(), v => string.IsNullOrEmpty(v) ? null : (Metadata)v);
    }
}

