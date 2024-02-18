#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.MembershipCommands;

public record MembershipSaveCommandHandlerRequest(Membership Membership) : IRequest<Membership>;