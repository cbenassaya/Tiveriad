using MediatR;

namespace Tiveriad.Multitenancy.Applications.Commands.UserCommands;

public record DeleteUserByIdRequest(ObjectId Id) : IRequest<bool>,ICommandRequest;