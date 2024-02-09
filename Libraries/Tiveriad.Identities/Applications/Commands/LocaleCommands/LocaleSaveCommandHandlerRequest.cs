
using MediatR;
using Tiveriad.Identities.Core.Entities;
namespace Tiveriad.Identities.Applications.Commands.LocaleCommands;

public record LocaleSaveCommandHandlerRequest(Locale Locale) : IRequest<Locale>;