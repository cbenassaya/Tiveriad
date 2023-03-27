#region

using Tiveriad.Workflows.Core.Services;

#endregion

namespace Tiveriad.Workflows.Core.Models;

public class ActionParameter<TStepBody, TData> : IStepParameter
{
    private readonly Action<TStepBody, TData, IStepExecutionContext> _action;

    public ActionParameter(Action<TStepBody, TData, IStepExecutionContext> action)
    {
        _action = action;
    }

    public ActionParameter(Action<TStepBody, TData> action)
    {
        _action = (body, data, context) => { action(body, data); };
    }

    public void AssignInput(object data, IStepBody body, IStepExecutionContext context)
    {
        Assign(data, body, context);
    }

    public void AssignOutput(object data, IStepBody body, IStepExecutionContext context)
    {
        Assign(data, body, context);
    }

    private void Assign(object data, IStepBody step, IStepExecutionContext context)
    {
        _action.Invoke((TStepBody)step, (TData)data, context);
    }
}