using System.Text.Json.Serialization;
using Tiveriad.Identities.Core.Entities;

namespace Tiveriad.Identities.Apis.Contracts.MembershipContracts;

public class MembershipEventModelContract
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public MembershipEvent Event { get; set; }
}