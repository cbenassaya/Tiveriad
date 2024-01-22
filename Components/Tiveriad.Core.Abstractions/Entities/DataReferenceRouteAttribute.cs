namespace Tiveriad.Core.Abstractions.Entities;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class DataReferenceRouteAttribute : Attribute
{
    public DataReferenceRouteAttribute(string route)
    {
        Route = route;
    }
        
    public string Route { get; set; }
}