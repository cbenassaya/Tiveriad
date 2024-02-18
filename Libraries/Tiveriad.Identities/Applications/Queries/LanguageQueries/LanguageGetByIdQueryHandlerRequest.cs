#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.LanguageQueries;

public record LanguageGetByIdQueryHandlerRequest(string Id) : IRequest<Language?>;