using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Tiveriad.Repositories;

namespace Tiveriad.DataReferences.Apis.Controllers;

public class DataReferenceControllerRouteConvention : IControllerModelConvention
{
    public void Apply(ControllerModel controller)
    {
        Console.WriteLine($"===> Controller: {controller.ControllerType.FullName}");
        if ( controller.ControllerType.IsGenericType)
        {
            var genericType = controller.ControllerType.GenericTypeArguments[0];
            var customNameAttribute = genericType.GetCustomAttribute<DataReferenceRouteAttribute>();
        
            if (customNameAttribute?.Route != null)
            {
                controller.Selectors.Add(new SelectorModel
                {
                    AttributeRouteModel = new AttributeRouteModel(new RouteAttribute(customNameAttribute.Route)),
                });
            }
        }
    }
    
    
}