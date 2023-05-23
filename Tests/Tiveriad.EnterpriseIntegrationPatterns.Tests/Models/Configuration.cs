#region

using Tiveriad.EnterpriseIntegrationPatterns.Pipelines;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.Tests.Models;

public class Configuration : IPipelineConfiguration
{
    public string Param1 { get; set; }
    public string Param2 { get; set; }
    public string Param3 { get; set; }
}