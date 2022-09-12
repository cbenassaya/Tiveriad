using Microsoft.Extensions.DependencyInjection;
using Tiveriad.Commons.Tests;
using Tiveriad.IdGenerators;
using Xunit;

namespace Tiveriad.IdGenerator.Tests;

public class Startup : StartupBase
{
    public override void Configure(IServiceCollection services)
    {
    }
}

public class IdGeneratorTest : TestBase<Startup>
{
    [Fact]
    public void Get_Long_Id()
    {
        var generator = new LongIdGenerator(0);
        var ids = generator.Take(1000).ToArray();
        var falseIds = ids.Where(x => x < 0 || x > long.MaxValue).ToArray();
        Assert.True(falseIds.Length == 0);
    }

    [Fact]
    public void Get_String_String()
    {
        var generator = new StringIdGenerator(new IdGeneratorOptions());
        var ids = generator.Take(1000).ToArray();
        Assert.Equal(1000, ids.Length);
    }
}