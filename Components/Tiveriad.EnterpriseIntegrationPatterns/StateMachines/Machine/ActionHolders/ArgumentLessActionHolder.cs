//-------------------------------------------------------------------------------

#region

using System.Reflection;
using Tiveriad.Commons.Extensions;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Machine.ActionHolders;

public class ArgumentLessActionHolder : IActionHolder
{
    private readonly Action action;

    public ArgumentLessActionHolder(Action action)
    {
        this.action = action;
    }

    public void Execute(object argument)
    {
        action();
    }

    public string Describe()
    {
        return action.GetMethodInfo().ExtractMethodNameOrAnonymous();
    }
}