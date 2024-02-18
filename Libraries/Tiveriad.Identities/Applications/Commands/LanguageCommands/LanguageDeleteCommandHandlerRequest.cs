#region

using MediatR;

#endregion

namespace Tiveriad.Identities.Applications.Commands.LanguageCommands;

public record LanguageDeleteCommandHandlerRequest(string Id) : IRequest<bool>;