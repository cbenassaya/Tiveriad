using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Tiveriad.ReferenceData.Apis.Controllers;

public class ReferenceDataControllerModelConvention : IControllerModelConvention
{
    public void Apply(ControllerModel controller)
    {
        var isVisible = !ReferenceDataControllerDefinition.TypeInfos.Contains(controller.ControllerType);
        controller.ApiExplorer.IsVisible = isVisible;
    }
}