#region

using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;
using Tiveriad.Workflows.Core.Services;

#endregion

namespace Tiveriad.Workflows.Services;

public class GreyList : IGreyList, IDisposable
{
    private const int CYCLE_TIME = 30;
    private const int TTL = 5;
    private readonly Timer _cycleTimer;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly ConcurrentDictionary<string, DateTime> _list;
    private readonly ILogger _logger;

    public GreyList(ILoggerFactory loggerFactory, IDateTimeProvider dateTimeProvider)
    {
        _logger = loggerFactory.CreateLogger<GreyList>();
        _dateTimeProvider = dateTimeProvider;
        _list = new ConcurrentDictionary<string, DateTime>();
        _cycleTimer = new Timer(Cycle, null, TimeSpan.FromMinutes(CYCLE_TIME), TimeSpan.FromMinutes(CYCLE_TIME));
    }

    public void Dispose()
    {
        _cycleTimer.Dispose();
    }

    public void Add(string id)
    {
        _list.AddOrUpdate(id, _dateTimeProvider.Now, (key, val) => _dateTimeProvider.Now);
    }

    public bool Contains(string id)
    {
        if (!_list.TryGetValue(id, out var start))
            return false;

        var result = start > _dateTimeProvider.Now.AddMinutes(-1 * TTL);

        if (!result)
            _list.TryRemove(id, out var _);

        return result;
    }

    public void Remove(string id)
    {
        _list.TryRemove(id, out var _);
    }

    private void Cycle(object target)
    {
        try
        {
            _list.Clear();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
        }
    }
}