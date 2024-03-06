namespace Tiveriad.Core.Abstractions.Entities;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class ReferenceDataRouteAttribute : Attribute
{
    public ReferenceDataRouteAttribute(string route)
    {
        Route = route;
    }
    public string Route { get;  }
}