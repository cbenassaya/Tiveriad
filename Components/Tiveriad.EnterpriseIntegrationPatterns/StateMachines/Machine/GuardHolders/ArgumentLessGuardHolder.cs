//-------------------------------------------------------------------------------

//-------------------------------------------------------------------------------

using System.Reflection;
using Tiveriad.Commons.Extensions;

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Machine.GuardHolders
{
    /// <summary>
    /// Holds an argument less guard.
    /// </summary>
    public class ArgumentLessGuardHolder : IGuardHolder
    {
        private readonly Func<bool> guard;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentLessGuardHolder"/> class.
        /// </summary>
        /// <param name="guard">The guard.</param>
        public ArgumentLessGuardHolder(Func<bool> guard)
        {
            this.guard = guard;
        }

        /// <summary>
        /// Executes the guard.
        /// </summary>
        /// <param name="argument">The state machine event argument.</param>
        /// <returns>Result of the guard execution.</returns>
        public bool Execute(object argument)
        {
            return this.guard();
        }

        /// <summary>
        /// Describes the guard.
        /// </summary>
        /// <returns>Description of the guard.</returns>
        public string Describe()
        {
            return this.guard.GetMethodInfo().ExtractMethodNameOrAnonymous();
        }
    }
}