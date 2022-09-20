using System.Reflection;
using Tiveriad.Pipelines.Tests.Models;
using Tiveriad.UnitTests;
using Xunit;

namespace Tiveriad.Pipelines.Tests;

public class PipelineTestModule : TestBase<PipelineStartup>
{
    [Fact]
    public void BuildPipeLine()
    {
        var pipelineBuilder = GetRequiredService<IPipelineBuilder<Model, Context, Configuration>>();
        pipelineBuilder
            .Configure(configuration =>
            {
                configuration.Param1 = "Test1";
                configuration.Param2 = "Test2";
                configuration.Param3 = "Test3";
            })
            .Use(async (context, model, next) =>
            {
                Assert.Equal("Test1", context.Configuration.Param1);
                context.Configuration.Param2 = "Test2";
                await next.Invoke(context, model);
            })
            .Use(async (context, model, next) =>
            {
                Assert.Equal("Test2", context.Configuration.Param2);
                context.Configuration.Param3 = "Test3";
                await next.Invoke(context, model);
            })
            .Use(async (context, model, next) =>
            {
                Assert.Equal("Test3", context.Configuration.Param3);
                await next.Invoke(context, model);
            })
            .Add<Middleware>()
            .Use(async (context, model, next) =>
            {
                Assert.NotNull(model.DateTime);
                await next.Invoke(context, model);
            });

        var pipeline = pipelineBuilder.Build();
        pipeline.Execute(new Model());
    }
}