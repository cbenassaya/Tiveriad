
using MediatR;
using System.Collections.Generic;
using Tiveriad.Notifications.Core.Entities;
using System;
namespace Tiveriad.Notifications.Applications.Queries.ScopeQueries;

public record ScopeGetAllQueryHandlerRequest(string? Id = null, int? Page = null, int? Limit = null, string? Q = null, IEnumerable<string>? Orders = null) : IRequest<List<Scope>>;