#region

using System.Reflection;
using Tiveriad.Commons.Extensions;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Machine.ActionHolders;

public class ParametrizedActionHolder<T> : IActionHolder
{
    private readonly Action<T> action;

    private readonly T parameter;

    public ParametrizedActionHolder(Action<T> action, T parameter)
    {
        this.action = action;
        this.parameter = parameter;
    }

    public void Execute(object argument)
    {
        action(parameter);
    }

    public string Describe()
    {
        return action.GetMethodInfo().ExtractMethodNameOrAnonymous();
    }
}