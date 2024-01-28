#region

using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Apis.Contracts.MembershipContracts;

public class MembershipWriterModel
{
    public string? Id { get; set; }

    public MembershipState? State { get; set; }

    public string UserId { get; set; }

    public string MembershipId { get; set; }
}