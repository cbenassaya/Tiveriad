using System.ComponentModel.DataAnnotations;

namespace Tiveriad.Multitenancy.Apis.Contracts;

public class UserStateUpdaterModel
{
    [Required]
    public string State { get; set; } = string.Empty;
}