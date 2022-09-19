using System.Dynamic;
using System.Net.Http.Headers;
using Tiveriad.Commons.Extensions;

namespace Tiveriad.Pipelines;

public class DefaultConfiguration :  IPipelineConfiguration
{
    public Dictionary<string, object> Properties { get; } = new();
    
    public virtual DefaultConfiguration WithProperty(string key, object value)
    {
        Properties[key] = value;
        return this;
    }
    public object this[string name] {
        get => Properties.GetOrDefault(name);
        set => Properties[name] = value;
    }
}