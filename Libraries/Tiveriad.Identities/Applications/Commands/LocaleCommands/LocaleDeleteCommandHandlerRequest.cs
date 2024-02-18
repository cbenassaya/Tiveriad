#region

using MediatR;

#endregion

namespace Tiveriad.Identities.Applications.Commands.LocaleCommands;

public record LocaleDeleteCommandHandlerRequest(string Id) : IRequest<bool>;