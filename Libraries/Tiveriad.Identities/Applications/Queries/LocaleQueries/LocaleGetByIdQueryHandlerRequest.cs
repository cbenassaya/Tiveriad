
using MediatR;
using Tiveriad.Identities.Core.Entities;
using System;
namespace Tiveriad.Identities.Applications.Queries.LocaleQueries;

public record LocaleGetByIdQueryHandlerRequest(string Id) : IRequest<Locale?>;