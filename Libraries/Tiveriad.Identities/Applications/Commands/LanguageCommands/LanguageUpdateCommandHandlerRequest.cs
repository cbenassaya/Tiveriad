#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.LanguageCommands;

public record LanguageUpdateCommandHandlerRequest(string Id, Language Language) : IRequest<Language>;