﻿namespace Tiveriad.Commons.RetryLogic;

public class RetryResult
{
    public RetryResult(RetryContext context)
    {
        Context = context;
    }

    public RetryContext Context { get; }

    public RetryResult<TResult> WithValue<TResult>(TResult value)
    {
        var result = new RetryResult<TResult>(Context, value);
        return result;
    }
}