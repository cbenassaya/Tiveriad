#region

using Tiveriad.Core.Abstractions.DomainEvents;
using Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;
using Tiveriad.EnterpriseIntegrationPatterns.Mediators;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.Tests.Models;

public record Request(string Name) : IRequest<int>;

public class RequestHandler : IRequestHandler<Request, int>
{
    public Task<int> Handle(Request request, CancellationToken cancellationToken)
    {
        return Task.FromResult(request.Name.Length);
    }
}

public class MessageDomainEvent : IDomainEvent<Guid>
{
    public string Message { get; set; }

    public DateTimeOffset OccurredOn { get; } = DateTimeOffset.Now;
    public Guid Id { get; } = Guid.NewGuid();
}