namespace Tiveriad.Integration.Core.Exceptions;

public class TiveriadIntegrationException : Exception
{
    public TiveriadIntegrationException(TiveriadIntegrationError error) : base(error.ToString())
    {
        Error = error;
    }

    public TiveriadIntegrationError Error { get; }
}