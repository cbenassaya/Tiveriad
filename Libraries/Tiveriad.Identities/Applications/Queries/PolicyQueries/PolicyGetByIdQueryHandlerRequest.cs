#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.PolicyQueries;

public record PolicyGetByIdQueryHandlerRequest(string Id) : IRequest<Policy?>;