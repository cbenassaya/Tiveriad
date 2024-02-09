namespace Tiveriad.Integration.Core.Exceptions;

public class TiveriadIntegrationError
{
    private TiveriadIntegrationError(string code, string label)
    {
        Code = code;
        Label = label;
    }

    public string Code { get; }

    public string Label { get; }

    public static TiveriadIntegrationError VALIDATION_ERROR(string code)
    {
        return new TiveriadIntegrationError(code, "VALIDATION ERROR");
    }

    public override string ToString()
    {
        return Code;
    }
}