#region

using System.Dynamic;

#endregion

namespace Tiveriad.Pipelines;

public class DefaultMessage<T>
{
    public DefaultMessage(T body)
    {
        Body = body;
    }

    public dynamic Header { get; } = new ExpandoObject();

    public T Body { get; }
}