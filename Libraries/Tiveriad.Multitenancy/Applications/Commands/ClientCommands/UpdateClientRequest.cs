using MediatR;
using Tiveriad.Multitenancy.Core.Entities;

namespace Tiveriad.Multitenancy.Applications.Commands.ClientCommands;

public record UpdateClientRequest(Client Client) : IRequest<Client>,ICommandRequest;