using System.Dynamic;
using Tiveriad.Commons.Extensions;

namespace Tiveriad.Pipelines;

public class DefaultPipelineContext : PipelineContextBase<DefaultConfiguration>, IPipelineContext<DefaultConfiguration>
{
    public Dictionary<string, object> Properties { get; } = new();

    public DefaultPipelineContext(DefaultConfiguration configuration, CancellationToken cancellationToken) : base(configuration, cancellationToken)
    {
    }
    
    public virtual DefaultPipelineContext WithProperty(string key, object value)
    {
        Properties[key] = value;
        return this;
    }
    public object this[string name] {
        get => Properties.GetOrDefault(name);
        set => Properties[name] = value;
    }
}