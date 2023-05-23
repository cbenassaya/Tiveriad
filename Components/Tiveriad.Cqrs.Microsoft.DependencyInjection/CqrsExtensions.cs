#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Tiveriad.Commons.Extensions;
using Tiveriad.Cqrs.Commands;
using Tiveriad.Cqrs.Queries;
using Tiveriad.Cqrs.Requests;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Cqrs.Microsoft.DependencyInjection;

public static class CqrsExtensions
{
    public static IServiceCollection AddGenericHandlers(this IServiceCollection services,
        params Assembly[] assembliesToScan)
    {
        var handlerDefinitions = new[]
        {
            new HandlerDefinition
            {
                RequestType = typeof(SaveOrUpdateRequest<,>),
                ResponseType = typeof(Unit),
                ServiceType = typeof(SaveOrUpdateRequestHandler<,>)
            },
            new HandlerDefinition
            {
                RequestType = typeof(RemoveByIRequest<,>),
                ResponseType = typeof(bool),
                ServiceType = typeof(RemoveByIdRequestHandler<,>)
            },
            new HandlerDefinition
            {
                RequestType = typeof(GetByIdRequest<,>),
                ServiceType = typeof(GetByIdRequestHandler<,>)
            },
            new HandlerDefinition
            {
                RequestType = typeof(GetAllRequest<,>),
                ResponseType = typeof(IEnumerable<>),
                ServiceType = typeof(GetAllRequestHandler<,>)
            }
        };

        var assembliesToScanArray = assembliesToScan ?? Array.Empty<Assembly>().ToArray();
        var allTypes = assembliesToScanArray
            .Where(a => !a.IsDynamic)
            .Distinct()
            .SelectMany(a => a.DefinedTypes)
            .ToArray();

        var openTypes = new[]
        {
            typeof(IEntity<>),
            typeof(EntityBase<>)
        };

        foreach (var type in openTypes.SelectMany(openType => allTypes
                     .Where(t => t.IsClass
                                 && !t.IsAbstract
                                 && t.AsType().ImplementsGenericInterface(openType))))
        {
            Type keyType = null;
            var implementedInterface =
                type.GetInterfaces().FirstOrDefault(x =>
                    x.Name.StartsWith("IEntity"));
            if (implementedInterface != null)
                keyType = implementedInterface.GetGenericArguments().FirstOrDefault();
            else if (type.BaseType is not null && type.BaseType.Name.StartsWith("EntityBase"))
                keyType = type.BaseType.GetGenericArguments().FirstOrDefault();

            if (keyType == null) continue;
            var typeParameters = new[] { type, keyType };

            foreach (var handlerDefinition in handlerDefinitions)
            {
                var requestType = handlerDefinition.RequestType.MakeGenericType(typeParameters);
                var responseType = handlerDefinition.ResponseType == null
                    ? type
                    : handlerDefinition.ResponseType.Name.StartsWith("IEnumerable")
                        ? typeof(IEnumerable<>).MakeGenericType(type)
                        : handlerDefinition.ResponseType;
                var implementedServiceType = handlerDefinition.ServiceType.MakeGenericType(typeParameters);
                var serviceType = typeof(IRequestHandler<,>).MakeGenericType(requestType, responseType);
                services.AddTransient(serviceType, implementedServiceType);
            }
        }


        return services;
    }

    private class HandlerDefinition
    {
        public Type ServiceType { get; set; }
        public Type ResponseType { get; set; }
        public Type RequestType { get; set; }
    }
}