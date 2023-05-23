//-------------------------------------------------------------------------------

#region

using System.Reflection;
using Tiveriad.Commons.Extensions;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine.ActionHolders;

public class ArgumentLessActionHolder : IActionHolder
{
    private readonly Func<Task> action;
    private readonly MethodInfo originalActionMethodInfo;

    public ArgumentLessActionHolder(Func<Task> action)
    {
        originalActionMethodInfo = action.GetMethodInfo();
        this.action = action;
    }

    public ArgumentLessActionHolder(Action action)
    {
        originalActionMethodInfo = action.GetMethodInfo();
        this.action = () =>
        {
            action();
            return Task.FromResult(0);
        };
    }

    public async Task Execute(object argument)
    {
        await action().ConfigureAwait(false);
    }

    public string Describe()
    {
        return originalActionMethodInfo.ExtractMethodNameOrAnonymous();
    }
}