
using MediatR;
using Tiveriad.Identities.Core.Entities;
using System;
namespace Tiveriad.Identities.Applications.Queries.TimeAreaQueries;

public record TimeAreaGetByIdQueryHandlerRequest(string Id) : IRequest<TimeArea?>;