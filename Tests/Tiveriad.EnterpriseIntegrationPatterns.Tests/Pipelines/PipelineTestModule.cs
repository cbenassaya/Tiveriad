#region

using Tiveriad.EnterpriseIntegrationPatterns.Pipelines;
using Tiveriad.EnterpriseIntegrationPatterns.Tests.Models;
using Tiveriad.UnitTests;
using Xunit;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.Tests.Pipelines;

public class PipelineTestModule : TestBase<PipelineStartup>
{
    [Fact]
    public void BuildPipeLine()
    {
        var pipelineBuilder = GetRequiredService<IPipelineBuilder< Context, Model, Configuration>>();
        pipelineBuilder
            .Configure(configuration =>
            {
                configuration.Param1 = "Test1";
                configuration.Param2 = "Test2";
                configuration.Param3 = "Test3";
            })
            .Use(async (context, next) =>
            {
                Assert.Equal("Test1", context.Configuration.Param1);
                Thread.Sleep(1000);
                context.Configuration.Param2 = "Test2";
                await next(context);
            })
            .Use( async (context, next) =>
            {
                Assert.Equal("Test2", context.Configuration.Param2);
                Thread.Sleep(3000);
                context.Configuration.Param3 = "Test3";
                await next(context);
            })
            .Use(async (context, next) =>
            {
                Assert.Equal("Test3", context.Configuration.Param3);
                Thread.Sleep(1000);
                await next(context);
            })
            .Add<Middleware>()
            .Use(async (context, next) =>
            {
                Assert.NotNull(context.Model.DateTime);
                context.Model.Name = "Test";
                await next(context);
            });

        var pipeline = pipelineBuilder.Build();
        var model = new Model();
        pipeline.Execute(model);
        Assert.NotNull(model.Name);
    }


    [Fact]
    public void BuildPipeLineWithException()
    {
        var pipelineBuilder = GetRequiredService<IPipelineBuilder< Context,Model, Configuration>>();
        pipelineBuilder
            .Configure(configuration =>
            {
                configuration.Param1 = "Test1";
                configuration.Param2 = "Test2";
                configuration.Param3 = "Test3";
            })
            .WithExceptionHandler((exception,context) =>
            {
                Assert.Equal(typeof(NullReferenceException), exception.GetType());
            })
            .Use(async (context,next) =>
            {
                Assert.Equal("Test1", context.Configuration.Param1);
                context.Configuration.Param2 = "Test2";
                await next(context);
            })
            .Add<MiddlewareWithException>()
            .Use(async (context, next) =>
            {
                Assert.Equal("Test2", context.Configuration.Param2);
                context.Configuration.Param3 = "Test3";
                await next(context);
            })
            .Use(async (context, model) =>
            {
                Assert.Equal("Test3", context.Configuration.Param3);
            })
            .Add<Middleware>()
            .Use(async (context, next) =>
            {
                Assert.NotNull(context.Model.DateTime);
                await next(context);
            });

        var pipeline = pipelineBuilder.Build();
        pipeline.Execute(new Model());
    }
}