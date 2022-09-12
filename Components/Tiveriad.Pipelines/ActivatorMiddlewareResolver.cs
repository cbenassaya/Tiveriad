namespace Tiveriad.Pipelines;

public class ActivatorMiddlewareResolver : IMiddlewareResolver
{
    public object Resolve(Type type)
    {
        return Activator.CreateInstance(type);
    }
}