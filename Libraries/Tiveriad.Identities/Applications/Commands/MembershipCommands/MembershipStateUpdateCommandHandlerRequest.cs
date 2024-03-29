using MediatR;
using Tiveriad.Identities.Core.Entities;

namespace Tiveriad.Identities.Applications.Commands.MembershipCommands;

public record MembershipStateUpdateCommandHandlerRequest(string Id, MembershipEvent Event) : IRequest<Membership>;


public record DefaultMembershipUpdateCommandHandlerRequest(string OrganizationId, string UserId) : IRequest<Membership>;