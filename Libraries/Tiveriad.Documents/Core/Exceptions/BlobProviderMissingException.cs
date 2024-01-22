namespace Tiveriad.Documents.Core.Exceptions;

public class BlobProviderMissingException : Exception
{
    public BlobProviderMissingException()
    {
    }

    public BlobProviderMissingException(string message)
        : base(message)
    {
    }

    public BlobProviderMissingException(string message, Exception inner)
        : base(message, inner)
    {
    }
}