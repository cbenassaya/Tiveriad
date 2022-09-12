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
}