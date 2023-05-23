//-------------------------------------------------------------------------------

//-------------------------------------------------------------------------------

using System.Reflection;
using Tiveriad.Commons.Extensions;

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine.ActionHolders
{
    public class ArgumentActionHolder<T> : IActionHolder
    {
        private readonly MethodInfo originalActionMethodInfo;
        private readonly Func<T, Task> action;

        public ArgumentActionHolder(Func<T, Task> action)
        {
            this.originalActionMethodInfo = action.GetMethodInfo();
            this.action = action;
        }

        public ArgumentActionHolder(Action<T> action)
        {
            this.originalActionMethodInfo = action.GetMethodInfo();
            this.action = argument =>
            {
                action(argument);
                return Task.FromResult(0);
            };
        }

        public async Task Execute(object argument)
        {
            T castArgument = default(T);

            if (argument != System.Reflection.Missing.Value && argument != null && !(argument is T))
            {
                throw new ArgumentException(ActionHoldersExceptionMessages.CannotCastArgumentToActionArgument(argument, this.Describe()));
            }

            if (argument != System.Reflection.Missing.Value)
            {
                castArgument = (T)argument;
            }

            await this.action(castArgument).ConfigureAwait(false);
        }

        public string Describe()
        {
            return this.originalActionMethodInfo.ExtractMethodNameOrAnonymous();
        }
    }
}