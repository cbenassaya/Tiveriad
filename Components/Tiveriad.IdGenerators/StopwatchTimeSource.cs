using System.Diagnostics;

namespace Tiveriad.IdGenerators;

/// <summary>
///     Provides time data to an <see cref="LongIdGenerator" />. This timesource uses a <see cref="Stopwatch" /> for
///     timekeeping.
/// </summary>
public abstract class StopwatchTimeSource : ITimeSource
{
    private static readonly Stopwatch _sw = new();
    private static readonly DateTimeOffset _initialized = DateTimeOffset.UtcNow;

    /// <summary>
    ///     Initializes a new <see cref="StopwatchTimeSource" /> object.
    /// </summary>
    /// <param name="epoch">The epoch to use as an offset from now,</param>
    /// <param name="tickDuration">The duration of a single tick for this timesource.</param>
    public StopwatchTimeSource(DateTimeOffset epoch, TimeSpan tickDuration)
    {
        Epoch = epoch;
        Offset = _initialized - Epoch;
        TickDuration = tickDuration;

        // Start (or resume) stopwatch
        _sw.Start();
    }

    /// <summary>
    ///     Gets the elapsed time since this <see cref="ITimeSource" /> was initialized.
    /// </summary>
    protected static TimeSpan Elapsed => _sw.Elapsed;

    /// <summary>
    ///     Gets the offset for this <see cref="ITimeSource" /> which is defined as the difference of it's creationdate
    ///     and it's epoch which is specified in the object's constructor.
    /// </summary>
    protected TimeSpan Offset { get; }

    /// <summary>
    ///     Gets the epoch of the <see cref="ITimeSource" />.
    /// </summary>
    public DateTimeOffset Epoch { get; }

    /// <summary>
    ///     Returns the duration of a single tick.
    /// </summary>
    public TimeSpan TickDuration { get; }

    /// <summary>
    ///     Returns the current number of ticks for the <see cref="DefaultTimeSource" />.
    /// </summary>
    /// <returns>The current number of ticks to be used by an <see cref="LongIdGenerator" /> when creating an Id.</returns>
    public abstract long GetTicks();
}