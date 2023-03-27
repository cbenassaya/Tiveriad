#region

using System.Linq.Expressions;
using Tiveriad.Workflows.Core.Services;

#endregion

namespace Tiveriad.Workflows.Core.Models;

public class ValueOutcome : IStepOutcome
{
    private LambdaExpression _value;

    public LambdaExpression Value
    {
        set => _value = value;
    }

    public int NextStep { get; set; }

    public string Label { get; set; }

    public string ExternalNextStepId { get; set; }

    public bool Matches(ExecutionResult executionResult, object data)
    {
        return Equals(GetValue(data), executionResult.OutcomeValue) || GetValue(data) == null;
    }

    public bool Matches(object data)
    {
        return GetValue(data) == null;
    }

    public object GetValue(object data)
    {
        if (_value == null)
            return null;

        return _value.Compile().DynamicInvoke(data);
    }
}