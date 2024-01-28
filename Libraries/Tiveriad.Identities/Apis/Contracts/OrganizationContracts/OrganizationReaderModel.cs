#region

using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Apis.Contracts.OrganizationContracts;

public class OrganizationReaderModel
{
    public string? Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public OrganizationState? State { get; set; }
}