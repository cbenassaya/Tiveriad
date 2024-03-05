namespace ReferenceData.Integration.Core.Exceptions;

public class ReferenceDataException : Exception
{
    public ReferenceDataException(ReferenceDataError error) : base(error.ToString())
    {
        Error = error;
    }

    public ReferenceDataError Error { get; }
}