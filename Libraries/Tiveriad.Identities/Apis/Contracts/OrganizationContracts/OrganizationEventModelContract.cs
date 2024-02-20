using System.Text.Json.Serialization;
using Tiveriad.Identities.Core.Entities;

namespace Tiveriad.Identities.Apis.Contracts.OrganizationContracts;

public class OrganizationEventModelContract
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public OrganizationEvent Event { get; set; }
}