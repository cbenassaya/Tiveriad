#region

using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

#endregion

namespace Tiveriad.ReferenceData.Apis.Controllers;

public class ReferenceDataControllerRouteConvention : IControllerModelConvention
{
    public void Apply(ControllerModel controller)
    {
        if (controller.ControllerType.IsGenericType)
        {
            var genericType = controller.ControllerType.GenericTypeArguments[0];
            var customNameAttribute = genericType.GetCustomAttribute<ReferenceDataRouteAttribute>();

            if (customNameAttribute?.Route != null)
                controller.Selectors.Add(new SelectorModel
                {
                    AttributeRouteModel = new AttributeRouteModel(new RouteAttribute(customNameAttribute.Route))
                });
        }
    }
}