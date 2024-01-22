namespace Tiveriad.Documents.Core.Exceptions;

public class DocumentError
{
    public static DocumentError BAD_REQUEST = new("BAD_REQUEST", "BAD REQUEST");
    public static DocumentError INTERNAL_ERROR = new("INTERNAL_ERROR", "INTERNAL ERROR");
    public static DocumentError DOCUMENT_NOT_FOUND = new("DOCUMENT_NOT_FOUND", "DOCUMENT NOT FOUND");

    public static DocumentError DOCUMENT_DEFINITION_NOT_FOUND =
        new("DOCUMENT_DEFINITION_NOT_FOUND", "DOCUMENT DEFINITION NOT FOUND");

    public static DocumentError NO_XXX = new("NO_XXX", "NO XXX");

    private DocumentError(string code, string label)
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