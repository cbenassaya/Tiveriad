namespace Tiveriad.Identities.Core.Entities;

public enum OrganizationState
{
    Pending,
    Validated,
    Canceled
}


public enum OrganizationEvent
{
    Validate,
    Cancel
}