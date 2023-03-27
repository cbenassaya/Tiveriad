#region

using System.Linq.Expressions;
using Tiveriad.Workflows.Core.Services;

#endregion

namespace Tiveriad.Workflows.Core.Models;

public class ExpressionOutcome<TData> : IStepOutcome
{
    private readonly Func<TData, object, bool> _func;

    public ExpressionOutcome(Expression<Func<TData, object, bool>> expression)
    {
        _func = expression.Compile();
    }


    public int NextStep { get; set; }

    public string Label { get; set; }

    public string ExternalNextStepId { get; set; }

    public bool Matches(ExecutionResult executionResult, object data)
    {
        return _func((TData)data, executionResult.OutcomeValue);
    }

    public bool Matches(object data)
    {
        return _func((TData)data, null);
    }
}