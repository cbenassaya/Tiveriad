
using MediatR;
using System;
namespace Tiveriad.Identities.Applications.Commands.LocaleCommands;

public record LocaleDeleteCommandHandlerRequest(string Id) : IRequest<bool>;