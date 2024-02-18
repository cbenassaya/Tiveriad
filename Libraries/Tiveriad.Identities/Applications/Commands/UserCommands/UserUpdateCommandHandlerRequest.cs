#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.UserCommands;

public record UserUpdateCommandHandlerRequest(User User) : IRequest<User>;