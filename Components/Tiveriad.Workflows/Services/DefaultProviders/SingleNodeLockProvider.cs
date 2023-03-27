﻿#region

using Tiveriad.Workflows.Core.Services;

#endregion

namespace Tiveriad.Workflows.Services.DefaultProviders;
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

/// <summary>
///     Single node in-memory implementation of IDistributedLockProvider
/// </summary>
public class SingleNodeLockProvider : IDistributedLockProvider
{
    private readonly HashSet<string> _locks = new();

    public async Task<bool> AcquireLock(string Id, CancellationToken cancellationToken)
    {
        lock (_locks)
        {
            if (_locks.Contains(Id))
                return false;

            _locks.Add(Id);
            return true;
        }
    }

    public async Task ReleaseLock(string Id)
    {
        lock (_locks)
        {
            _locks.Remove(Id);
        }
    }

    public async Task Start()
    {
    }

    public async Task Stop()
    {
    }
}

#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously