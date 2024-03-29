﻿namespace Tiveriad.Commons.RetryLogic;

public class RetryCondition
{
    public RetryCondition(Retry retry, Func<RetryConditionHandle, bool> predicate)
    {
        Retry = retry;
        Retry.Conditions.Add(this);
        FilterCondition = predicate;
    }

    public Retry Retry { get; set; }

    public Func<RetryConditionHandle, bool> FilterCondition { get; }
    public Func<RetryConditionHandle, bool> TerminationCondition { get; private set; }

    public Retry For(uint times)
    {
        TerminationCondition = handle => handle.Occurences > times;
        return Retry;
    }

    public Retry For(TimeSpan duration)
    {
        TerminationCondition = handle =>
        {
            var durationSinceFirstOccured = DateTimeOffset.Now - handle.FirstOccured;
            var result = durationSinceFirstOccured > duration;
            return result;
        };

        return Retry;
    }

    public Retry Until(Func<RetryConditionHandle, bool> predicate)
    {
        TerminationCondition = predicate;
        return Retry;
    }

    public Retry Indefinitely()
    {
        TerminationCondition = handle => false;
        return Retry;
    }
}