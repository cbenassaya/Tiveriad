#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Identities.Applications.Commands.ClientCommands;

public class SaveClientPreValidator : AbstractValidator<SaveClientRequest>
{

    public SaveClientPreValidator(IRepository<Client, string> clientRepository)
    {
        RuleFor(x => x.Client).NotNull().WithMessage("Client is required").WithErrorCode("IDENTITIES_CLIENT_SAVE_CLIENT_REQUIRED");
        RuleFor(x => x.Client.Name).NotEmpty().WithMessage("Name is required").WithErrorCode("IDENTITIES_CLIENT_SAVE_NAME_REQUIRED");
        RuleFor(x => x.Client.Code).NotEmpty().WithMessage("Code is required").WithErrorCode("IDENTITIES_CLIENT_SAVE_CODE_REQUIRED");
        RuleFor(x => x.OrganizationId).NotEmpty().WithMessage("OrganizationId is required").WithErrorCode("IDENTITIES_CLIENT_SAVE_ORGANIZATIONID_REQUIRED");
        RuleFor(x => x).Must( request =>
        {
            var client =  clientRepository
                .Queryable
                .FirstOrDefault(c => c.Name == request.Client.Name  && c.Organization.Id == request.OrganizationId);
            
            return client == null;
        }).WithMessage("Client exists yet").WithErrorCode("IDENTITIES_CLIENT_SAVE_EXISTS");
    }
}