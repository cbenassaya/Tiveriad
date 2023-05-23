//-------------------------------------------------------------------------------

//-------------------------------------------------------------------------------

using System.Reflection;
using Tiveriad.Commons.Extensions;

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine.ActionHolders
{
    public class ArgumentLessActionHolder : IActionHolder
    {
        private readonly MethodInfo originalActionMethodInfo;
        private readonly Func<Task> action;

        public ArgumentLessActionHolder(Func<Task> action)
        {
            this.originalActionMethodInfo = action.GetMethodInfo();
            this.action = action;
        }

        public ArgumentLessActionHolder(Action action)
        {
            this.originalActionMethodInfo = action.GetMethodInfo();
            this.action = () =>
            {
                action();
                return Task.FromResult(0);
            };
        }

        public async Task Execute(object argument)
        {
            await this.action().ConfigureAwait(false);
        }

        public string Describe()
        {
            return this.originalActionMethodInfo.ExtractMethodNameOrAnonymous();
        }
    }
}