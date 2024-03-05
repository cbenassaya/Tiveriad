namespace ReferenceData.Integration.Core.Exceptions;

public class ReferenceDataError
{
    private ReferenceDataError(string code, string label)
    {
        Code = code;
        Label = label;
    }

    public string Code { get; }

    public string Label { get; }

    public static ReferenceDataError VALIDATION_ERROR(string code)
    {
        return new ReferenceDataError(code, "VALIDATION ERROR");
    }

    public override string ToString()
    {
        return Code;
    }
}