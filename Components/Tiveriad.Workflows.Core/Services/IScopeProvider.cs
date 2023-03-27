﻿#region

using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Tiveriad.Workflows.Core.Services;

/// <remarks>
///     The implemention of this interface will be responsible for
///     providing a new service scope for a DI container
/// </remarks>
public interface IScopeProvider
{
    /// <summary>
    ///     Create a new service scope
    /// </summary>
    /// <returns></returns>
    IServiceScope CreateScope(IStepExecutionContext context);
}