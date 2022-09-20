using Tiveriad.Pipelines.Tests.Models;
using Tiveriad.UnitTests;
using Xunit;

namespace Tiveriad.Pipelines.Tests;

public class SenderTestModule : TestBase<SenderStartup>
{
    [Fact]
    public void Send_Test()
    {
        var result = GetRequiredService<ISender>().Send<int>(new Request("Hello World"));
        
        Assert.Equal(11, result?.Result);
    }
}