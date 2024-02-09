
using MediatR;
using System;
namespace Tiveriad.Identities.Applications.Commands.LanguageCommands;

public record LanguageDeleteCommandHandlerRequest(string Id) : IRequest<bool>;