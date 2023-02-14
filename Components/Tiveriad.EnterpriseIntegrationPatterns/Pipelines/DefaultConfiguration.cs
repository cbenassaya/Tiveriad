using Tiveriad.Commons.Extensions;

namespace Tiveriad.EnterpriseIntegrationPatterns.Pipelines;

public class DefaultConfiguration : IPipelineConfiguration
{
    public Dictionary<string, object> Properties { get; } = new();

    public object this[string name]
    {
        get => Properties.GetOrDefault(name);
        set => Properties[name] = value;
    }

    public virtual DefaultConfiguration WithProperty(string key, object value)
    {
        Properties[key] = value;
        return this;
    }
}