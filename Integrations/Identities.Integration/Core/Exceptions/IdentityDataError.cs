namespace Identities.Integration.Core.Exceptions;

public class IdentityDataError
{
    private IdentityDataError(string code, string label)
    {
        Code = code;
        Label = label;
    }

    public string Code { get; }

    public string Label { get; }

    public static IdentityDataError VALIDATION_ERROR(string code)
    {
        return new IdentityDataError(code, "VALIDATION ERROR");
    }

    public override string ToString()
    {
        return Code;
    }
}