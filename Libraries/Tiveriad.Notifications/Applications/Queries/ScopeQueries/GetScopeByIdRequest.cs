#region

using MediatR;
using Tiveriad.Notifications.Core.Entities;

#endregion

namespace Tiveriad.Notifications.Application.Queries.ScopeQueries;

public record GetScopeByIdRequest(string Id) : IRequest<Scope?>;