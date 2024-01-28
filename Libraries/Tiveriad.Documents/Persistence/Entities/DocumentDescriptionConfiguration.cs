#region

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Documents.Core.Entities;

#endregion

namespace Tiveriad.Documents.Persistence.Entities;

public class DocumentDescriptionConfiguration : IEntityTypeConfiguration<DocumentDescription>
{
    public void Configure(EntityTypeBuilder<DocumentDescription> builder)
    {
        builder.ToTable("T_DocumentDescription");
        // <-- Id -->
        builder.HasKey(b => b.Id).HasName("PK_DocumentDescriptionId");
        // <-- ManyToOne -->
        builder.HasOne(b => b.DocumentCategory);
        // <-- OneToMany -->

        // <-- Enum -->
        builder.Property(e => e.State)
            .HasConversion(v => v.ToString(), v => (DocumentState)Enum.Parse(typeof(DocumentState), v));
        // <-- Object -->
        builder.Property(e => e.Description).HasConversion(v => v == null ? string.Empty : v.ToString(),
            v => string.IsNullOrEmpty(v) ? null : (InternationalizedString)v);
        builder.Property(e => e.Properties).HasConversion(v => v == null ? string.Empty : v.ToString(),
            v => string.IsNullOrEmpty(v) ? null : (Metadata)v);
    }
}