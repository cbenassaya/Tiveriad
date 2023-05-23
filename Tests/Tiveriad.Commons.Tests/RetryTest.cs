#region

using Tiveriad.Commons.RetryLogic;
using Tiveriad.UnitTests;
using Xunit;

#endregion

namespace Tiveriad.Commons.Tests;

public class RetryTest : TestBase<Startup>
{
    [Fact]
    public void ProcessCommandTest()
    {
        Retry.On<Exception>().For(3).Execute(x => { });
    }
}