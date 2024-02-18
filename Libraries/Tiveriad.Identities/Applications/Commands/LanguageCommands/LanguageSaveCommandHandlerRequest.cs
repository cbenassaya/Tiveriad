#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.LanguageCommands;

public record LanguageSaveCommandHandlerRequest(Language Language) : IRequest<Language>;