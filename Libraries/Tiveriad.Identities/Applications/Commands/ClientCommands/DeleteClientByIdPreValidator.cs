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
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required").WithErrorCode("IDENTITIES_CLIENT_DELETE_ID_REQUIRED");
        RuleFor(x => x.OrganizationId).NotEmpty().WithMessage("OrganizationId is required").WithErrorCode("IDENTITIES_CLIENT_DELETE_ORGANIZATIONID_REQUIRED");
        RuleFor(x => x).Must( request =>
        {
            var client =  clientRepository
                .Queryable
                .FirstOrDefault(c => c.Id == request.Id  && c.Organization.Id == request.OrganizationId);
            
            return client != null;
        }).WithMessage("Client not found").WithErrorCode("IDENTITIES_CLIENT_DELETE_NOT_FOUND");
    }
}