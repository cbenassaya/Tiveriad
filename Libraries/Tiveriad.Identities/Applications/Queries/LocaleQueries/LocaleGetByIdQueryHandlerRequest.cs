#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.LocaleQueries;

public record LocaleGetByIdQueryHandlerRequest(string Id) : IRequest<Locale?>;