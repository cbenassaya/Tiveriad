#region

using System.Diagnostics;
using MediatR;

#endregion

namespace Identities.Integration.Applications.Pipelines;

public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<TRequest> _logger;
    private readonly Stopwatch _timer;

    public PerformanceBehaviour(
        ILogger<TRequest> logger)
    {
        _timer = new Stopwatch();
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<TResponse> Handle(TRequest request,
        RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _timer.Start();

        var response = await next();

        _timer.Stop();

        var elapsedMilliseconds = _timer.ElapsedMilliseconds;

        if (elapsedMilliseconds <= 500) return response;
        var requestName = typeof(TRequest).Name;
        _logger.LogWarning("Long Running Request: {RequestName} ({ElapsedMilliseconds} milliseconds)  {Request}",
            requestName, elapsedMilliseconds, request);

        return response;
    }
}