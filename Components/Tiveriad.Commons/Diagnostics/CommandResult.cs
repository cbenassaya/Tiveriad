using System.Diagnostics;

namespace Tiveriad.Commons.Diagnostics;

public struct CommandResult
{
    public static readonly CommandResult Empty = new();
    public ProcessStartInfo StartInfo { get; }
    public int ExitCode { get; }

    public CommandResult(ProcessStartInfo startInfo, int exitCode)
    {
        StartInfo = startInfo;
        ExitCode = exitCode;
    }
}