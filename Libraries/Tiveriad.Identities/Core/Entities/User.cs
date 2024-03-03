#region

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace Tiveriad.Identities.Core.Entities;

public class User : IEntity<string>, IAuditable<string>
{
    [MaxLength(100)] [Required] public string Firstname { get; set; } = default!;
    [MaxLength(100)] [Required] public string Lastname { get; set; } = default!;
    [MaxLength(100)] [Required] public string Username { get; set; } = default!;
    [NotMapped] [MaxLength(12)] [Required] public string Password { get; set; } = default!;
    [MaxLength(100)] [Required] public string Email { get; set; } = default!;
    [MaxLength(24)] public string? Avatar { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public Metadata? Properties { get; set; }
    public string? LanguageId { get; set; }
    public string? LocaleId { get; set; }
    [Required] public string CreatedBy { get; set; } = default!;
    [Required] public DateTime Created { get; set; } = default!;
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }


    [MaxLength(24)] [Required] public string Id { get; set; } = default!;
}