#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.LocaleCommands;

public record LocaleUpdateCommandHandlerRequest(Locale Locale) : IRequest<Locale>;