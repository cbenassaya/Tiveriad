
using MediatR;
using Tiveriad.Identities.Core.Entities;
namespace Tiveriad.Identities.Applications.Commands.MembershipCommands;

public record MembershipUpdateCommandHandlerRequest(Membership Membership) : IRequest<Membership>;