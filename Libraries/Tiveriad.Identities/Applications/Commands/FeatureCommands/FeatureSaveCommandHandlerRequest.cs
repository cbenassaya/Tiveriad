#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.FeatureCommands;

public record FeatureSaveCommandHandlerRequest(string RealmId,Feature Feature) : IRequest<Feature>;