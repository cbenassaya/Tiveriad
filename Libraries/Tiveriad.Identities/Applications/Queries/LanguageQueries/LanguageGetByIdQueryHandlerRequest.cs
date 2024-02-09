
using MediatR;
using Tiveriad.Identities.Core.Entities;
using System;
namespace Tiveriad.Identities.Applications.Queries.LanguageQueries;

public record LanguageGetByIdQueryHandlerRequest(string Id) : IRequest<Language?>;