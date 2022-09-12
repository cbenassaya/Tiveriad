namespace Tiveriad.Pipelines.Tests.Models;

public class Context : IPipelineContext<Configuration>
{
    public CancellationToken CancellationToken { get; set; }
    public Configuration Configuration { get; set; } 
}