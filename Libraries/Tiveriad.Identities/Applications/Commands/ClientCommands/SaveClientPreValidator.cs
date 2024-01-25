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
        RuleFor(x => x.Client).NotNull()
            .WithErrorCode("Tiveriad.Identities.Client.SaveCommand:ClientRequired");
        RuleFor(x => x.Client.Name).NotEmpty()
            .WithErrorCode("Tiveriad.Identities.Client.SaveCommand:NameRequired");
        RuleFor(x => x.Client.Code).NotEmpty()
            .WithErrorCode("Tiveriad.Identities.Client.SaveCommand:CodeRequired");
        RuleFor(x => x.OrganizationId).NotEmpty().
            WithErrorCode("Tiveriad.Identities.Client.SaveCommand:OrganizationIdRequired");
        RuleFor(x => x).Must( request =>
        {
            var client =  clientRepository
                .Queryable
                .FirstOrDefault(c => c.Name == request.Client.Name  && c.Organization.Id == request.OrganizationId);
            
            return client == null;
        }).WithErrorCode("Tiveriad.Identities.Client.SaveCommand:ClientAlreadyExists");
    }
}