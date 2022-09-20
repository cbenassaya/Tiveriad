namespace Tiveriad.Pipelines;

public class ActivatorServiceResolver : IServiceResolver
{
    public object Resolve(Type type)
    {
        return Activator.CreateInstance(type);
    }
}