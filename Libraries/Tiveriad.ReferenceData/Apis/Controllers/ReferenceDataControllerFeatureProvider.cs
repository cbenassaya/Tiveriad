using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Tiveriad.Commons.Extensions;
using Tiveriad.ReferenceData.Core.Entities;

namespace Tiveriad.ReferenceData.Apis.Controllers;

public class ReferenceDataControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
{
    private readonly IEnumerable<Assembly> _assembliesToScan;


    public ReferenceDataControllerFeatureProvider(IEnumerable<Assembly> assembliesToScan)
    {
        _assembliesToScan = assembliesToScan;
    }

    public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
    {
        var allTypes = _assembliesToScan
            .Where(a => !a.IsDynamic)
            .Distinct()
            .SelectMany(a => a.DefinedTypes)
            .ToArray();

        foreach (var typeInfo in  allTypes
                     .Where(t => t.IsClass
                                 && !t.IsAbstract
                                 && t.BaseType == typeof(KeyValue)).ToList())
        {
            foreach (var genericType in ReferenceDataControllerDefinition.TypeInfos)
            {
                var controllerType = genericType.MakeGenericType([typeInfo.AsType()]);
                if (feature.Controllers.Contains(controllerType.GetTypeInfo())) continue;
                feature.Controllers.Add(controllerType.GetTypeInfo());
            }
        }
    }
}