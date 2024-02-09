
using MediatR;
using System;
namespace Tiveriad.Registrations.Applications.Commands.RegistrationCommands;

public record RegistrationDeleteCommandHandlerRequest(string Id) : IRequest<bool>;