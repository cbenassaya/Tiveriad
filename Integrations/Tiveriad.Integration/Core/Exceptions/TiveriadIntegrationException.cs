namespace Tiveriad.Integration.Core.Exceptions
{
    public class TiveriadIntegrationException : Exception
    {
        private TiveriadIntegrationError _error;

        public TiveriadIntegrationException(TiveriadIntegrationError error) : base(error.ToString())
        {
            _error = error;
        }

        public TiveriadIntegrationError Error => _error;
    }
}