#region

using Microsoft.Extensions.DependencyInjection;
using Tiveriad.Workflows.Core.Services;

#endregion

namespace Tiveriad.Workflows.Services;

/// <summary>
///     A concrete implementation for the IScopeProvider interface
///     Could be used for context-aware scope creation customization
/// </summary>
public class ScopeProvider : IScopeProvider
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public ScopeProvider(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public IServiceScope CreateScope(IStepExecutionContext context)
    {
        return _serviceScopeFactory.CreateScope();
    }
}