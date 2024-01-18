using MediatR;

namespace Tiveriad.Multitenancy.Applications.Commands.ClientCommands;

public record DeleteClientByIdRequest(ObjectId Id) : IRequest<bool>,ICommandRequest;