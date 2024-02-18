#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.LanguageCommands;

public record LanguageUpdateCommandHandlerRequest(Language Language) : IRequest<Language>;