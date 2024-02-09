
using MediatR;
using Tiveriad.Identities.Core.Entities;
namespace Tiveriad.Identities.Applications.Commands.LanguageCommands;

public record LanguageSaveCommandHandlerRequest(Language Language) : IRequest<Language>;