using Tiveriad.Commons.Extensions;

namespace Tiveriad.Pipelines;

public class DefaultPipelineContext : PipelineContextBase<DefaultConfiguration>, IPipelineContext<DefaultConfiguration>
{
    public DefaultPipelineContext(DefaultConfiguration configuration, CancellationToken cancellationToken) : base(
        configuration, cancellationToken)
    {
    }

    public Dictionary<string, object> Properties { get; } = new();

    public object this[string name]
    {
        get => Properties.GetOrDefault(name);
        set => Properties[name] = value;
    }

    public virtual DefaultPipelineContext WithProperty(string key, object value)
    {
        Properties[key] = value;
        return this;
    }
}