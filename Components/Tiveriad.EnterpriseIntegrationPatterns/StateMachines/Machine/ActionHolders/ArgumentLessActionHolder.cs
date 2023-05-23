//-------------------------------------------------------------------------------

//-------------------------------------------------------------------------------

using System.Reflection;
using Tiveriad.Commons.Extensions;

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Machine.ActionHolders
{
    public class ArgumentLessActionHolder : IActionHolder
    {
        private readonly Action action;

        public ArgumentLessActionHolder(Action action)
        {
            this.action = action;
        }

        public void Execute(object argument)
        {
            this.action();
        }

        public string Describe()
        {
            return this.action.GetMethodInfo().ExtractMethodNameOrAnonymous();
        }
    }
}