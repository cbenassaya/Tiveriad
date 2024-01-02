//-------------------------------------------------------------------------------

#region

using System.Reflection;
using Tiveriad.Commons.Extensions;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.GuardHolders;

/// <summary>
///     Holds an argument less guard.
/// </summary>
public class ArgumentLessGuardHolder : IGuardHolder
{
    private readonly Func<Task<bool>> guard;
    private readonly MethodInfo originalGuardMethodInfo;

    /// <summary>
    ///     Initializes a new instance of the <see cref="ArgumentLessGuardHolder" /> class.
    /// </summary>
    /// <param name="guard">The guard.</param>
    public ArgumentLessGuardHolder(Func<bool> guard)
    {
        originalGuardMethodInfo = guard.GetMethodInfo();
        this.guard = () => Task.FromResult(guard());
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ArgumentLessGuardHolder" /> class.
    /// </summary>
    /// <param name="guard">The guard.</param>
    public ArgumentLessGuardHolder(Func<Task<bool>> guard)
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
        return await guard().ConfigureAwait(false);
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