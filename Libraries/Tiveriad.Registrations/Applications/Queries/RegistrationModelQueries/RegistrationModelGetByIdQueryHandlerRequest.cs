
using MediatR;
using Tiveriad.Registrations.Core.Entities;
using System;
namespace Tiveriad.Registrations.Applications.Queries.RegistrationModelQueries;

public record RegistrationModelGetByIdQueryHandlerRequest(string Id) : IRequest<RegistrationModel?>;