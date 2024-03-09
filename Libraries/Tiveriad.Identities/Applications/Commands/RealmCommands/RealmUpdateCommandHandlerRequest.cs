#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.RealmCommands;

public record RealmUpdateCommandHandlerRequest(string Id, Realm Realm) : IRequest<Realm>;