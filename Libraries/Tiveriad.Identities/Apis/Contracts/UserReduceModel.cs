#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace Tiveriad.Identities.Apis.Contracts;

public class UserReduceModel
{
    [MaxLength(24)] public string Id { get; set; }

    [MaxLength(100)] public string Email { get; set; }

    [MaxLength(50)] public string Firstname { get; set; }

    [MaxLength(50)] public string Lastname { get; set; }

    [MaxLength(500)] public string? Description { get; set; }
}