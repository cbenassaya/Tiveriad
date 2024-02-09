
using MediatR;
using System;
namespace Tiveriad.Identities.Applications.Commands.TimeAreaCommands;

public record TimeAreaDeleteCommandHandlerRequest(string Id) : IRequest<bool>;