using MediatR;
using Tiveriad.Multitenancy.Core.Entities;

namespace Tiveriad.Multitenancy.Applications.Commands.UserCommands;

public record UpdateMembershipStateRequest(ObjectId OrganizationId, ObjectId userId , MembershipState state) : IRequest<User>,ICommandRequest;