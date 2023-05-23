

using System.Reflection;
using Tiveriad.Commons.Extensions;

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine.ActionHolders
{
    public class ParametrizedActionHolder<T> : IActionHolder
    {
        private readonly MethodInfo originalActionMethodInfo;
        private readonly Func<T, Task> action;
        private readonly T parameter;

        public ParametrizedActionHolder(Func<T, Task> action, T parameter)
        {
            this.originalActionMethodInfo = action.GetMethodInfo();
            this.action = action;
            this.parameter = parameter;
        }

        public ParametrizedActionHolder(Action<T> action, T parameter)
        {
            this.originalActionMethodInfo = action.GetMethodInfo();
            this.action = argument =>
            {
                action(argument);
                return Task.FromResult(0);
            };

            this.parameter = parameter;
        }

        public async Task Execute(object argument)
        {
            await this.action(this.parameter).ConfigureAwait(false);
        }

        public string Describe()
        {
            return this.originalActionMethodInfo.ExtractMethodNameOrAnonymous();
        }
    }
}