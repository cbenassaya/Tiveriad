using System.Text;
using Tiveriad.Commons.Diagnostics;
using Tiveriad.UnitTests;
using Xunit;

namespace Tiveriad.Commons.Tests;

public class ZeroTestModule : TestBase<Startup>
{
    [Fact]
    public void ZeroTest()
    {
        var zeroService = GetService<ZeroService>();
        Assert.NotNull(zeroService);
    }

    [Fact]
    public void ProcessCommandTest()
    {
        var error = new StringBuilder();
        var output = new StringBuilder();
        ProcessCommand
            .Create("dotnet", "--info")
            .OnOutputLine(item => output.AppendLine(item))
            .OnErrorLine(item => error.AppendLine(item))
            .Execute();

        Assert.Equal(0, error.Length);
    }


}