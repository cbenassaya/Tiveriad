//-------------------------------------------------------------------------------

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Models;

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