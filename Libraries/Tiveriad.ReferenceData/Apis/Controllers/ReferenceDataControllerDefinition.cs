#region

using System.Reflection;
using Tiveriad.ReferenceData.Apis.EndPoints.KeyValueEndPoints;

#endregion

namespace Tiveriad.ReferenceData.Apis.Controllers;

public static class ReferenceDataControllerDefinition
{
    public static TypeInfo[] TypeInfos =
    {
        typeof(GetAllEndPoint<>).GetTypeInfo(),
        typeof(GetByIdEndPoint<>).GetTypeInfo(),
        typeof(PostEndPoint<>).GetTypeInfo(),
        typeof(PutEndPoint<>).GetTypeInfo(),
        typeof(DeleteEndPoint<>).GetTypeInfo()
    };
}