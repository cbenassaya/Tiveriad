
using MediatR;
using Tiveriad.Registrations.Core.Entities;
using System;
namespace Tiveriad.Registrations.Applications.Queries.RegistrationQueries;

public record RegistrationGetByIdQueryHandlerRequest(string Id) : IRequest<Registration?>;