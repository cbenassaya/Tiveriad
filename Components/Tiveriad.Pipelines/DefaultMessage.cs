using System.Dynamic;

namespace Tiveriad.Pipelines;

public class DefaultMessage<T>
{

    private readonly dynamic _header = new ExpandoObject();
    private readonly T _body;
    public dynamic Header => _header;
    public T Body => _body;

    public DefaultMessage(T body)
    {
        _body = body;
    }
}