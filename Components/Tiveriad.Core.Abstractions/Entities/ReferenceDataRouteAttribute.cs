namespace Tiveriad.Core.Abstractions.Entities;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class ReferenceDataRouteAttribute : Attribute
{
    public ReferenceDataRouteAttribute(string route, bool multiTenant = true, string prefix = "api")
    {
        Route = $"{prefix}/{(multiTenant ? "organizations/{organizationId}" : string.Empty)}/{route}";
    }
    public string Route { get;  }
}