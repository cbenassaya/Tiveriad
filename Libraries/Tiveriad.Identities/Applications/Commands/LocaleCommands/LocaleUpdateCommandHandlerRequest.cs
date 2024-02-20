#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.LocaleCommands;

public record LocaleUpdateCommandHandlerRequest(string Id,Locale Locale) : IRequest<Locale>;