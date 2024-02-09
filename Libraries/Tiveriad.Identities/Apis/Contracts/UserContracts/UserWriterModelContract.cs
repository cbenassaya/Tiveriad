
using System;
using Tiveriad.Core.Abstractions.Entities;
using System.ComponentModel.DataAnnotations;
namespace Tiveriad.Identities.Apis.Contracts.UserContracts;

public class UserWriterModelContract
{


    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public string? ProfileImage { get; set; }
    public Metadata? Properties { get; set; }
    [Required] public string LanguageId { get; set; } = default!;
    [Required] public string LocaleId { get; set; } = default!;

}

