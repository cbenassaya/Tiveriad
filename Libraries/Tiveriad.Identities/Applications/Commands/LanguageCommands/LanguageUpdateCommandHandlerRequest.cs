
using MediatR;
using Tiveriad.Identities.Core.Entities;
namespace Tiveriad.Identities.Applications.Commands.LanguageCommands;

public record LanguageUpdateCommandHandlerRequest(Language Language) : IRequest<Language>;