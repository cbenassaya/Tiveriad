namespace Tiveriad.Identities.Core.Entities;

public enum MembershipState
{
    Pending,
    Validated,
    Canceled
}


public enum MembershipEvent
{
    Validate,
    Cancel
}