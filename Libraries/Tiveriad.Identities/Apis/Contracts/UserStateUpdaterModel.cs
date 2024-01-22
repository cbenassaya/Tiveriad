#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace Tiveriad.Identities.Apis.Contracts;

public class UserStateUpdaterModel
{
    [Required] public string State { get; set; } = string.Empty;
}