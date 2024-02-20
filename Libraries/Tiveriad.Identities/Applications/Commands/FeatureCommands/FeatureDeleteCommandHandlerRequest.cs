#region

using MediatR;

#endregion

namespace Tiveriad.Identities.Applications.Commands.FeatureCommands;

public record FeatureDeleteCommandHandlerRequest(string RealmId, string Id) : IRequest<bool>;