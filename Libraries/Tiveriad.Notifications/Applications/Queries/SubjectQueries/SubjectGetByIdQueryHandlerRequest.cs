
using MediatR;
using Tiveriad.Notifications.Core.Entities;
using System;
namespace Tiveriad.Notifications.Applications.Queries.SubjectQueries;

public record SubjectGetByIdQueryHandlerRequest(string Id) : IRequest<Subject?>;