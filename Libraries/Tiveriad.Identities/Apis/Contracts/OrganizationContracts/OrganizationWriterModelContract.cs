#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Apis.Contracts.OrganizationContracts;

public class OrganizationWriterModelContract
{
    public string? Name { get; set; }
    public string? Domain { get; set; }
    public string? Description { get; set; }
    public Metadata? Properties { get; set; }
    [Required] public string OwnerId { get; set; } = default!;
    [Required] public string TimeAreaId { get; set; } = default!;
}

public class OrganizationUpdaterModelContract
{
    public string? Name { get; set; }
    public string? Domain { get; set; }
    public string? Description { get; set; }
    public Metadata? Properties { get; set; }
    [Required] public string TimeAreaId { get; set; } = default!;
}

public class OrganizationEventModelContract
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public OrganizationEvent Event { get; set; }
}