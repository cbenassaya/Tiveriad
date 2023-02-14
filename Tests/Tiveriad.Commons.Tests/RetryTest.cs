using Tiveriad.Commons.RetryLogic;
using Tiveriad.UnitTests;
using Xunit;

namespace Tiveriad.Commons.Tests;

public class RetryTest: TestBase<Startup>
{
    [Fact]
    public void ProcessCommandTest()
    {
        Retry.On<Exception>().For(3).Execute(x =>
        {
    
        });
    }
}