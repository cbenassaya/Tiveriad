namespace Tiveriad.Pipelines.Tests.Models;

public record Request (string Name) :IRequest<int>;

public class RequestHandler: IRequestHandler<Request, int>
{
    public Task<int> Handle(Request request, CancellationToken cancellationToken)
    {
        return Task.FromResult(request.Name.Length);
    }
}