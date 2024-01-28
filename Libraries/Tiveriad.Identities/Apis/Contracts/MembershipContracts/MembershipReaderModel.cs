#region

using Tiveriad.Identities.Apis.Contracts.UserContracts;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Apis.Contracts.MembershipContracts;

public class MembershipReaderModel
{
    public string? Id { get; set; }

    public MembershipState? State { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? Created { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public UserReduceModel? User { get; set; }

    public MembershipReduceModel? Membership { get; set; }
}