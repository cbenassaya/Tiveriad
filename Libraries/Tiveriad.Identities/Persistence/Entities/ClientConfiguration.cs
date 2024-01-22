#region

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Persistence.Entities;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("T_Client");

        // <-- Id -->
        builder.HasKey(b => b.Id).HasName("PK_ClientId");
        // <-- ManyToOne -->
        builder.Navigation(x => x.Organization).IsRequired();
        // <-- OneToMany -->
        // <-- Enum -->

        // <-- Object -->
    }
}