namespace Tiveriad.Documents.Core.Exceptions;

public class DocumentException : Exception
{
    public DocumentException(DocumentError error) : base(error.ToString())
    {
        Error = error;
    }

    public DocumentError Error { get; }
}