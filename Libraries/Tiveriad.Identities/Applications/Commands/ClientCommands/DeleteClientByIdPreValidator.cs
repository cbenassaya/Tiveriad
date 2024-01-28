#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Identities.Core.Exceptions;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Identities.Applications.Commands.ClientCommands;

public class DeleteClientByIdPreValidator : AbstractValidator<DeleteClientByIdRequest>
{
    public DeleteClientByIdPreValidator(IRepository<Client, string> clientRepository)
    {
        RuleFor(x => x.Id).NotEmpty()
            .WithErrorCode(IdentifiesErrorCodes.TiveriadIdentitiesClientDeleteCommandIdRequired);
        RuleFor(x => x.OrganizationId).NotEmpty()
            .WithErrorCode(IdentifiesErrorCodes.TiveriadIdentitiesClientDeleteCommandOrganizationIdRequired);

        RuleFor(x => x).Must(request =>
        {
            var client = clientRepository
                .Queryable
                .FirstOrDefault(c => c.Id == request.Id && c.Organization.Id == request.OrganizationId);

            return client != null;
        }).WithErrorCode(IdentifiesErrorCodes.TiveriadIdentitiesClientDeleteCommandNotFound);
    }
}