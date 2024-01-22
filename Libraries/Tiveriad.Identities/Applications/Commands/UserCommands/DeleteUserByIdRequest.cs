#region

using MediatR;

#endregion

namespace Tiveriad.Identities.Applications.Commands.UserCommands;

public record DeleteUserByIdRequest(string Id) : IRequest<bool>, ICommandRequest;