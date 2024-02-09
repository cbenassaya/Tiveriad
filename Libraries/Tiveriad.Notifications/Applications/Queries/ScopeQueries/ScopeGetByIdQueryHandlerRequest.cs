
using MediatR;
using Tiveriad.Notifications.Core.Entities;
using System;
namespace Tiveriad.Notifications.Applications.Queries.ScopeQueries;

public record ScopeGetByIdQueryHandlerRequest(string Id) : IRequest<Scope?>;