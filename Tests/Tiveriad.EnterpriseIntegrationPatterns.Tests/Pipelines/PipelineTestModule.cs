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
        var pipelineBuilder = GetRequiredService<IPipelineBuilder<Model, Context, Configuration>>();
        pipelineBuilder
            .Configure(configuration =>
            {
                configuration.Param1 = "Test1";
                configuration.Param2 = "Test2";
                configuration.Param3 = "Test3";
            })
            .Use((context, model) =>
            {
                Assert.Equal("Test1", context.Configuration.Param1);
                context.Configuration.Param2 = "Test2";
                return Task.CompletedTask;
            })
            .Use((context, model) =>
            {
                Assert.Equal("Test2", context.Configuration.Param2);
                context.Configuration.Param3 = "Test3";
                return Task.CompletedTask;
            })
            .Use((context, model) =>
            {
                Assert.Equal("Test3", context.Configuration.Param3);
                return Task.CompletedTask;
            })
            .Add<Middleware>()
            .Use((context, model) =>
            {
                Assert.NotNull(model.DateTime);
                return Task.CompletedTask;
            });

        var pipeline = pipelineBuilder.Build();
        pipeline.Execute(new Model());
    }


    [Fact]
    public void BuildPipeLineWithException()
    {
        var pipelineBuilder = GetRequiredService<IPipelineBuilder<Model, Context, Configuration>>();
        pipelineBuilder
            .Configure(configuration =>
            {
                configuration.Param1 = "Test1";
                configuration.Param2 = "Test2";
                configuration.Param3 = "Test3";
            })
            .WithExceptionHandler(exception =>
            {
                Assert.Equal(typeof(NullReferenceException), exception.GetType());
            })
            .Use((context, model) =>
            {
                Assert.Equal("Test1", context.Configuration.Param1);
                context.Configuration.Param2 = "Test2";
                return Task.CompletedTask;
            })
            .Add<MiddlewareWithException>()
            .Use((context, model) =>
            {
                Assert.Equal("Test2", context.Configuration.Param2);
                context.Configuration.Param3 = "Test3";
                return Task.CompletedTask;
            })
            .Use((context, model) =>
            {
                Assert.Equal("Test3", context.Configuration.Param3);
                return Task.CompletedTask;
            })
            .Add<Middleware>()
            .Use((context, model) =>
            {
                Assert.NotNull(model.DateTime);
                return Task.CompletedTask;
            });

        var pipeline = pipelineBuilder.Build();
        pipeline.Execute(new Model());
    }
}