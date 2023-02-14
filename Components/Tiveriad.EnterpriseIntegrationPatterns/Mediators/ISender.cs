namespace Tiveriad.EnterpriseIntegrationPatterns.Mediators;

public interface ISender
{
    Task<TResponse>? Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
}