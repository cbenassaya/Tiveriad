//-------------------------------------------------------------------------------

#region

using System.Reflection;
using Tiveriad.Commons.Extensions;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.ActionHolders;

public class ArgumentActionHolder<T> : IActionHolder
{
    private readonly Func<T, Task> action;
    private readonly MethodInfo originalActionMethodInfo;

    public ArgumentActionHolder(Func<T, Task> action)
    {
        originalActionMethodInfo = action.GetMethodInfo();
        this.action = action;
    }

    public ArgumentActionHolder(Action<T> action)
    {
        originalActionMethodInfo = action.GetMethodInfo();
        this.action = argument =>
        {
            action(argument);
            return Task.FromResult(0);
        };
    }

    public async Task Execute(object argument)
    {
        var castArgument = default(T);

        if (argument != System.Reflection.Missing.Value && argument != null && !(argument is T))
            throw new ArgumentException(
                ActionHoldersExceptionMessages.CannotCastArgumentToActionArgument(argument, Describe()));

        if (argument != System.Reflection.Missing.Value) castArgument = (T)argument;

        await action(castArgument).ConfigureAwait(false);
    }

    public string Describe()
    {
        return originalActionMethodInfo.ExtractMethodNameOrAnonymous();
    }
}