//-------------------------------------------------------------------------------

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine;

/// <summary>
///     Specifies the type of the record.
/// </summary>
public enum RecordType
{
    /// <summary>
    ///     A state was entered.
    /// </summary>
    Enter,

    /// <summary>
    ///     A state was exited.
    /// </summary>
    Exit
}