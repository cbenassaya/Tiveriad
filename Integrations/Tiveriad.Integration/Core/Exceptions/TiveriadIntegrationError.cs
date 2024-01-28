namespace Tiveriad.Integration.Core.Exceptions
{
    public class TiveriadIntegrationError
    {
        public static TiveriadIntegrationError VALIDATION_ERROR(string code) => new(code,"VALIDATION ERROR");
        
        private readonly string _code;
        private readonly string _label;

        private TiveriadIntegrationError(string code, string label)
        {
            _code = code;
            _label = label;
        }

        public override string ToString()
        {
            return _code;
        }
        
        public string Code => _code;
        public string Label => _label;
    }
}