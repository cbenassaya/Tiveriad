#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.FeatureQueries;

public record FeatureGetByIdQueryHandlerRequest(string RealmId,string Id) : IRequest<Feature?>;