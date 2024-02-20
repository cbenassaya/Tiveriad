#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.FeatureCommands;

public record FeatureUpdateCommandHandlerRequest(string RealmId, string Id, Feature Feature) : IRequest<Feature>;