namespace Tiveriad.Identities.Core.Exceptions;

public class IdentitiesException : Exception
{
    public IdentitiesException(IdentitiesError error) : base(error.ToString())
    {
        Error = error;
    }


    public IdentitiesError Error { get; }
}

public class IdentitiesError
{
    public static IdentitiesError BAD_REQUEST = new("BAD_REQUEST", "BAD REQUEST");
    public static IdentitiesError USER_UNKNOWN = new("USER_UNKNOWN", "USER UNKNOWN");
    public static IdentitiesError INTERNAL_ERROR = new("INTERNAL_ERROR", "INTERNAL ERROR");

    private IdentitiesError(string code, string label)
    {
        Code = code;
        Label = label;
    }

    public string Code { get; }

    public string Label { get; }

    public override string ToString()
    {
        return $"{Code} - {Label}";
    }
}