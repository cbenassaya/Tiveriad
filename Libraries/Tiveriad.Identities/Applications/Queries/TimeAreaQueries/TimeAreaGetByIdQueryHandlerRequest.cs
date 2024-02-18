#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.TimeAreaQueries;

public record TimeAreaGetByIdQueryHandlerRequest(string Id) : IRequest<TimeArea?>;