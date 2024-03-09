namespace Identities.Integration.Core.Exceptions;

public class IdentityException(IdentityDataError error) : Exception(error.ToString())
{
    public IdentityDataError Error { get; } = error;
}