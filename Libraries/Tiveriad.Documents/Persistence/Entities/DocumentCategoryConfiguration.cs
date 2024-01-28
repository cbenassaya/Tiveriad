#region

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tiveriad.Documents.Core.Entities;

#endregion

namespace Tiveriad.Documents.Persistence.Entities;

public class DocumentCategoryConfiguration : IEntityTypeConfiguration<DocumentCategory>
{
    public void Configure(EntityTypeBuilder<DocumentCategory> builder)
    {
        builder.ToTable("T_DocumentCategory");
        // <-- Id -->
        builder.HasKey(b => b.Id).HasName("PK_DocumentCategoryId");
        // <-- ManyToOne -->

        // <-- OneToMany -->

        // <-- Enum -->

        // <-- Object -->
    }
}