#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.UserCommands;

public record SaveUserRequest(string OrganizationId, string ClientId, User User) : IRequest<User>, ICommandRequest;