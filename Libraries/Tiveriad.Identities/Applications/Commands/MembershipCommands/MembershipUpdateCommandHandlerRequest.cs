
using MediatR;
using Tiveriad.Identities.Core.Entities;
using System;
namespace Tiveriad.Identities.Applications.Commands.MembershipCommands;

public record MembershipUpdateCommandHandlerRequest(string Id, Membership Membership) : IRequest<Membership>;