
using MediatR;
using System;
namespace Tiveriad.Identities.Applications.Commands.UserCommands;

public record UserDeleteCommandHandlerRequest(string Id) : IRequest<bool>;