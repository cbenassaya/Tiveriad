#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace Tiveriad.Identities.Apis.Contracts.RoleContracts;

public class RoleWriterModelContract
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Code { get; set; }
}