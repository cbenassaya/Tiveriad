using System.Reflection;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Tiveriad.Commons.Extensions;
using Tiveriad.DataReferences.Apis.EndPoints;
using Tiveriad.Repositories;

namespace Tiveriad.DataReferences.Apis.Controllers;


public static class GenericControllerDefinition
{
    public static TypeInfo[] TypeInfos = new[]
    {
        typeof(GetAllEndPoint<,>).GetTypeInfo(),
        typeof(GetByIdEndPoint<,>).GetTypeInfo(),
        typeof(PostEndPoint<,>).GetTypeInfo(),
        typeof(PutEndPoint<,>).GetTypeInfo(),
        typeof(DeleteEndPoint<,>).GetTypeInfo()
    };
}



public class DataReferenceControllerModelConvention : IControllerModelConvention
{
    public void Apply(ControllerModel controller)
    {
        var isVisible =!GenericControllerDefinition.TypeInfos.Contains(controller.ControllerType);
        controller.ApiExplorer.IsVisible = isVisible;
    }
}

public class DataReferenceControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
{
    private readonly IEnumerable<Assembly> _assembliesToScan;


    public DataReferenceControllerFeatureProvider(IEnumerable<Assembly> assembliesToScan)
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

        var openTypes = new[]
        {
            typeof(IDataReference<>),
            typeof(DataReferenceBase<>)
        };

        foreach (var type in openTypes.SelectMany(openType => allTypes
                     .Where(t => t.IsClass
                                 && !t.IsAbstract
                                 && t.AsType().ImplementsGenericInterface(openType))))
        {
            Type keyType = null;
            var implementedInterface =
                type.GetInterfaces().FirstOrDefault(x =>
                    x.Name.StartsWith("IDataReference"));
            if (implementedInterface != null)
                keyType = implementedInterface.GetGenericArguments().FirstOrDefault();
            else if (type.BaseType is not null && type.BaseType.Name.StartsWith("DataReferenceBase"))
                keyType = type.BaseType.GetGenericArguments().FirstOrDefault();

            if (keyType == null) continue;
            var typeParameters = new[] { type, keyType };

            foreach (var genericType in GenericControllerDefinition.TypeInfos)
            {
                var controllerType = genericType.MakeGenericType(typeParameters);
                Console.WriteLine($"ADD ===> Controller: {controllerType.FullName}");
                if (feature.Controllers.Contains(controllerType.GetTypeInfo())) continue;
                
                //var controller = CreateDerivedType(controllerType.GetTypeInfo().AsType(),$"{genericType.Name}<{type.Name},{keyType.Name}>");
                
                feature.Controllers.Add(controllerType.GetTypeInfo());
            }
        }
        
         
    }
    
    
    private Type CreateDerivedType(Type baseType, string name)
    {
        // Create a dynamic assembly
        AssemblyName assemblyName = new AssemblyName("DynamicAssembly");
        AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);

        // Create a dynamic module
        ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("DynamicModule");

        // Create a dynamic type derived from the abstract base type
        TypeBuilder typeBuilder = moduleBuilder.DefineType(name, TypeAttributes.Public | TypeAttributes.Class, baseType);

        // Define a default constructor
        ConstructorBuilder constructorBuilder = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, Type.EmptyTypes);
        ILGenerator ilGenerator = constructorBuilder.GetILGenerator();
        ilGenerator.Emit(OpCodes.Ret);

        // Create the type
        Type generatedType = typeBuilder.CreateType();

        return generatedType;
    }
}