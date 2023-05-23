//-------------------------------------------------------------------------------

#region

using System.Reflection;
using Tiveriad.Commons.Extensions;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine.GuardHolders;

/// <summary>
///     Holds a single argument guard.
/// </summary>
/// <typeparam name="T">Type of the argument of the guard.</typeparam>
public class ArgumentGuardHolder<T> : IGuardHolder
{
    private readonly Func<T, Task<bool>> guard;
    private readonly MethodInfo originalGuardMethodInfo;

    /// <summary>
    ///     Initializes a new instance of the <see cref="ArgumentGuardHolder{T}" /> class.
    /// </summary>
    /// <param name="guard">The guard.</param>
    public ArgumentGuardHolder(Func<T, bool> guard)
    {
        originalGuardMethodInfo = guard.GetMethodInfo();
        this.guard = argument => guard(argument) ? Task.FromResult(true) : Task.FromResult(false);
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ArgumentGuardHolder{T}" /> class.
    /// </summary>
    /// <param name="guard">The guard.</param>
    public ArgumentGuardHolder(Func<T, Task<bool>> guard)
    {
        originalGuardMethodInfo = guard.GetMethodInfo();
        this.guard = guard;
    }

    /// <summary>
    ///     Executes the guard.
    /// </summary>
    /// <param name="argument">The state machine event argument.</param>
    /// <returns>Result of the guard execution.</returns>
    public async Task<bool> Execute(object argument)
    {
        if (argument != null && !(argument is T))
            throw new ArgumentException(
                GuardHoldersExceptionMessages.CannotCastArgumentToGuardArgument(argument, Describe()));

        return await guard((T)argument).ConfigureAwait(false);
    }

    /// <summary>
    ///     Describes the guard.
    /// </summary>
    /// <returns>Description of the guard.</returns>
    public string Describe()
    {
        return originalGuardMethodInfo.ExtractMethodNameOrAnonymous();
    }
}