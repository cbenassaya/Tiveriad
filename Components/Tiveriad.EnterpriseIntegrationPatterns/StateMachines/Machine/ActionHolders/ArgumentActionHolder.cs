//-------------------------------------------------------------------------------

#region

using System.Reflection;
using Tiveriad.Commons.Extensions;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Machine.ActionHolders;

public class ArgumentActionHolder<T> : IActionHolder
{
    private readonly Action<T> action;

    public ArgumentActionHolder(Action<T> action)
    {
        this.action = action;
    }

    public void Execute(object argument)
    {
        var castArgument = default(T);

        if (argument != System.Reflection.Missing.Value && argument != null && !(argument is T))
            throw new ArgumentException(
                ActionHoldersExceptionMessages.CannotCastArgumentToActionArgument(argument, Describe()));

        if (argument != System.Reflection.Missing.Value) castArgument = (T)argument;

        action(castArgument);
    }

    public string Describe()
    {
        return action.GetMethodInfo().ExtractMethodNameOrAnonymous();
    }
}