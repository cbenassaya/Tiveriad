#region

using Tiveriad.EnterpriseIntegrationPatterns.Mediators;
using Tiveriad.EnterpriseIntegrationPatterns.Tests.Models;
using Tiveriad.UnitTests;
using Xunit;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.Tests.Mediators;

public class SenderTestModule : TestBase<SenderStartup>
{
    [Fact]
    public void Send_Test()
    {
        var result = GetRequiredService<ISender>().Send(new Request("Hello World"));

        Assert.Equal(11, result?.Result);
    }
}