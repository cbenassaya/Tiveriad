#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.MembershipCommands;

public record MembershipUpdateCommandHandlerRequest(string Id, Membership Membership) : IRequest<Membership>;