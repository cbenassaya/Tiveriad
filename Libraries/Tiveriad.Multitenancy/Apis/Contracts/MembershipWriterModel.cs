using Tiveriad.Multitenancy.Core.Entities;

namespace Tiveriad.Multitenancy.Apis.Contracts;
public class MembershipWriterModel
{
    public string? Id { get; set; }

    public MembershipState? State { get; set; }

    public string UserId { get; set; }

    public string MembershipId { get; set; }
}