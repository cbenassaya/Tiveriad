
using MediatR;
using Tiveriad.Identities.Core.Entities;
using System;
namespace Tiveriad.Identities.Applications.Commands.OrganizationCommands;

public record OrganizationUpdateCommandHandlerRequest(string Id, Organization Organization) : IRequest<Organization>;