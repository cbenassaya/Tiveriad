#region

using System.Diagnostics;
using System.Runtime.CompilerServices;

#endregion

namespace Tiveriad.Commons.Diagnostics;

public class ProcessCommand
{
    private readonly Process _process;
    private bool _running;
    private Action<string> _stdErrorHandler;
    private Action<string> _stdOutHandler;

    private ProcessCommand(string commandName, IEnumerable<string> args)
    {
        var psi = new ProcessStartInfo
        {
            FileName = commandName,
            WindowStyle = ProcessWindowStyle.Hidden,
            Arguments = string.Join(" ", args),
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true
        };

        _process = new Process
        {
            StartInfo = psi
        };
    }

    public static ProcessCommand Create(string commandName, params string[] args)
    {
        return new ProcessCommand(commandName, args ?? Enumerable.Empty<string>());
    }

    public ProcessCommand InWorkingDirectory(string workingDir)
    {
        if (string.IsNullOrEmpty(workingDir)) throw new ArgumentException(nameof(workingDir));

        _process.StartInfo.WorkingDirectory = workingDir;
        return this;
    }

    public ProcessCommand WithEnvironmentVariable(string name, string value)
    {
        _process.StartInfo.EnvironmentVariables[name] = value;
        return this;
    }

    public override string ToString()
    {
        var psi = _process.StartInfo;
        return $"{psi.FileName} {psi.Arguments}";
    }

    public CommandResult Execute()
    {
        ThrowIfRunning();

        _running = true;
        _process.EnableRaisingEvents = true;


        _process.OutputDataReceived += OnOutputReceived;
        _process.ErrorDataReceived += OnErrorReceived;

        _process.Start();
        _process.BeginOutputReadLine();
        _process.BeginErrorReadLine();

        _process.WaitForExit();

        var exitCode = _process.ExitCode;

        _process.OutputDataReceived -= OnOutputReceived;
        _process.ErrorDataReceived -= OnErrorReceived;

        return new CommandResult(
            _process.StartInfo,
            exitCode);
    }

    private void OnErrorReceived(object sender, DataReceivedEventArgs e)
    {
        if (e.Data != null) _stdErrorHandler?.Invoke(e.Data);
    }

    private void OnOutputReceived(object sender, DataReceivedEventArgs e)
    {
        if (e.Data != null) _stdOutHandler?.Invoke(e.Data);
    }

    public ProcessCommand OnOutputLine(Action<string> handler)
    {
        ThrowIfRunning();
        _stdOutHandler = handler;
        return this;
    }

    public ProcessCommand OnErrorLine(Action<string> handler)
    {
        ThrowIfRunning();
        _stdErrorHandler = handler;
        return this;
    }

    private void ThrowIfRunning([CallerMemberName] string memberName = null)
    {
        if (_running)
            throw new InvalidOperationException($"Unable to invoke {memberName} after the command has been run");
    }
}