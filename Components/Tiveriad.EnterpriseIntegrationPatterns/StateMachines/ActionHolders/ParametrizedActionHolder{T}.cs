#region

using System.Reflection;
using Tiveriad.Commons.Extensions;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.ActionHolders;

public class ParametrizedActionHolder<T> : IActionHolder
{
    private readonly Func<T, Task> action;
    private readonly MethodInfo originalActionMethodInfo;
    private readonly T parameter;

    public ParametrizedActionHolder(Func<T, Task> action, T parameter)
    {
        originalActionMethodInfo = action.GetMethodInfo();
        this.action = action;
        this.parameter = parameter;
    }

    public ParametrizedActionHolder(Action<T> action, T parameter)
    {
        originalActionMethodInfo = action.GetMethodInfo();
        this.action = argument =>
        {
            action(argument);
            return Task.FromResult(0);
        };

        this.parameter = parameter;
    }

    public async Task Execute(object argument)
    {
        await action(parameter).ConfigureAwait(false);
    }

    public string Describe()
    {
        return originalActionMethodInfo.ExtractMethodNameOrAnonymous();
    }
}