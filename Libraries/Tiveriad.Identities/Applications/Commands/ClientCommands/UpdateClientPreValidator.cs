#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Identities.Applications.Commands.ClientCommands;

public class UpdateClientPreValidator : AbstractValidator<UpdateClientRequest>
{

    public UpdateClientPreValidator(IRepository<Client, string> clientRepository)
    {
        RuleFor(x => x.Client).NotNull().WithMessage("Client is required").WithErrorCode("IDENTITIES_CLIENT_UPDATE_CLIENT_REQUIRED");
        RuleFor(x => x.Client.Name).NotEmpty().WithMessage("Name is required").WithErrorCode("IDENTITIES_CLIENT_UPDATE_NAME_REQUIRED");
        RuleFor(x => x.Client.Code).NotEmpty().WithMessage("Code is required").WithErrorCode("IDENTITIES_CLIENT_UPDATE_CODE_REQUIRED");
        RuleFor(x => x.OrganizationId).NotEmpty().WithMessage("OrganizationId is required").WithErrorCode("IDENTITIES_CLIENT_UPDATE_ORGANIZATIONID_REQUIRED");
        RuleFor(x => x).Must( request =>
        {
            var client =  clientRepository
                .Queryable
                .FirstOrDefault(c => c.Id == request.Client.Id  && c.Organization.Id == request.OrganizationId);
            
            return client != null;
        }).WithMessage("Client not found").WithErrorCode("IDENTITIES_CLIENT_UPDATE_NOT_FOUND");
        RuleFor(x => x).Must( request =>
        {
            var client =  clientRepository
                .Queryable
                .FirstOrDefault(c =>  c.Name == request.Client.Name  && c.Id !=request.Client.Id && c.Organization.Id == request.OrganizationId);
            
            return client == null;
        }).WithMessage("Client with the same name exists yet").WithErrorCode("IDENTITIES_CLIENT_UPDATE_EXISTS");
    }
}