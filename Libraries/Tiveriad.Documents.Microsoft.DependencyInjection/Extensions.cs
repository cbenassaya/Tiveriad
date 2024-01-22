#region

using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Tiveriad.Commons.Extensions;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.DataReferences.Apis.Controllers;
using Tiveriad.DataReferences.Applications.Commands;
using Tiveriad.DataReferences.Applications.Queries;
using Tiveriad.Documents.Applications.Commands;
using Tiveriad.Documents.Applications.Queries;

#endregion

namespace Tiveriad.DataReferences.Apis.Microsoft.DependencyInjection;

public static class DataReferencesExtensions
{
    private static readonly HandlerDefinition[] _handlerDefinitions =
    {
        new()
        {
            RequestType = typeof(SaveDocumentDescriptionRequest<>),
            ResponseType = typeof(Unit),
            ServiceType = typeof(SaveDocumentDescriptionRequestHandler<>)
        },
        new()
        {
            RequestType = typeof(UpdateDocumentDescriptionRequest<>),
            ResponseType = typeof(Unit),
            ServiceType = typeof(UpdateDocumentDescriptionRequestHandler<>)
        },
        new()
        {
            RequestType = typeof(DeleteDocumentDescriptionByIdRequest<>),
            ResponseType = typeof(long),
            ServiceType = typeof(DeleteDocumentDescriptionByIdRequestHandler<>)
        },
        new()
        {
            RequestType = typeof(GetDocumentDescriptionByIdRequest<>),
            ResponseType = typeof(Unit),
            ServiceType = typeof(GetDocumentDescriptionByIdRequestHandler<>)
        },
        new()
        {
            RequestType = typeof(GetAllDocumentDescriptionRequest<>),
            ResponseType = typeof(IEnumerable<>),
            ServiceType = typeof(GetAllDocumentDescriptionRequestHandler<>)
        }
    };


    public static IServiceCollection AddDataReferences(this IServiceCollection services,
        params Assembly[] assembliesToScan)
    {
        services.AddGenericHandlers(assembliesToScan);
        services.AddGenericControllers(assembliesToScan);
        return services;
    }

    private static IServiceCollection AddGenericControllers(this IServiceCollection services,
        params Assembly[] assembliesToScan)
    {
        services
            .AddControllers(o =>
            {
                o.Conventions.Add(
                    new DataReferenceControllerRouteConvention()
                );
            })
            .ConfigureApplicationPartManager(m =>
            {
                m.FeatureProviders.Add(new DataReferenceControllerFeatureProvider(assembliesToScan));
            });
        return services;
    }

    private static IServiceCollection AddGenericHandlers(this IServiceCollection services,
        params Assembly[] assembliesToScan)
    {
        var assembliesToScanArray = assembliesToScan ?? Array.Empty<Assembly>().ToArray();
        var allTypes = assembliesToScanArray
            .Where(a => !a.IsDynamic)
            .Distinct()
            .SelectMany(a => a.DefinedTypes)
            .ToArray();

        var openTypes = new[]
        {
            typeof(DocumentDescriptionBase<>)
        };

        foreach (var type in openTypes.SelectMany(openType => allTypes
                     .Where(t => t.IsClass
                                 && !t.IsAbstract
                                 && t.AsType().IsInheritedBy(openType))))
        {
            Type keyType = null;
            if (type.BaseType is not null && type.BaseType.Name.StartsWith("DocumentDescriptionBase"))
                keyType = type.BaseType.GetGenericArguments().FirstOrDefault();

            if (keyType == null) continue;

            foreach (var handlerDefinition in _handlerDefinitions)
                AddEntity(services, handlerDefinition, type, keyType);
        }


        return services;
    }

    private static void AddEntity(this IServiceCollection services, HandlerDefinition handlerDefinition, Type type,
        Type keyType)
    {
        var typeParameters = new[] { type, keyType };
        Type responseType = null;
        var requestType = handlerDefinition.RequestType.MakeGenericType(typeParameters);

        if (handlerDefinition.ResponseType.Equals(typeof(Unit)))
            responseType = type;
        else if (handlerDefinition.ResponseType.Name.StartsWith("IEnumerable"))
            responseType = typeof(IEnumerable<>).MakeGenericType(type);
        else
            responseType = handlerDefinition.ResponseType;

        var implementedServiceType = handlerDefinition.ServiceType.MakeGenericType(typeParameters);
        var serviceType = typeof(IRequestHandler<,>).MakeGenericType(requestType, responseType);
        services.AddTransient(serviceType, implementedServiceType);
    }
}

public class HandlerDefinition
{
    public Type ServiceType { get; set; }
    public Type ResponseType { get; set; }
    public Type RequestType { get; set; }
}