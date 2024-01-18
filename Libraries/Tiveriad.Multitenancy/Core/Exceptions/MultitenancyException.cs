namespace Tiveriad.Multitenancy.Core.Exceptions;

public class MultiTenancyException:Exception
{
    public MultiTenancyException(MultiTenancyError error) : base(error.ToString())
    {
        Error = error;
    }
    

    public MultiTenancyError Error { get; }
}

public class MultiTenancyError
{
    public static MultiTenancyError BAD_REQUEST = new("BAD_REQUEST", "BAD REQUEST");
    public static MultiTenancyError USER_UNKNOWN = new("USER_UNKNOWN", "USER UNKNOWN");
    public static MultiTenancyError INTERNAL_ERROR = new("INTERNAL_ERROR", "INTERNAL ERROR");
    
    private MultiTenancyError(string code, string label)
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