using System.Dynamic;
using System.Net.Http.Headers;

namespace Tiveriad.Pipelines;

public class DefaultConfiguration :  IPipelineConfiguration
{
    public DefaultConfiguration()
    {
        Properties = new ExpandoObject();
    }

    public dynamic Properties { get; }
}