using FluentValidation;
using Tiveriad.Multitenancy.Core.Entities;
using Tiveriad.Repositories;

namespace Tiveriad.Multitenancy.Applications.Commands.UserCommands;
public class SaveUserPreValidator : AbstractValidator<SaveUserRequest>
{
    public SaveUserPreValidator(IRepository<User, ObjectId> userRepository, IRepository<Organization,ObjectId> organizationRepository)
    {
        RuleFor(x => x.OrganizationId)
            .NotNull().NotEmpty()
            .WithMessage("OrganizationId cannot be null or empty");
        
        
        RuleFor(x => x.OrganizationId)
            .MustAsync((id, cancellationToken) =>
            {
                var query = organizationRepository.Queryable.Where(x => x.Id.Equals(id));
                return Task.FromResult(query.Any());
            }).WithMessage("Organization not exists");
        
        RuleFor(x => x.User)
            .NotNull()
            .WithMessage("User cannot be null");
                
        RuleFor(x => x.User.Email)
            .EmailAddress()
            .WithMessage("Email's User is not valid");
        
        RuleFor(x => x.User.Username)
            .NotNull()
            .WithMessage("Username's User cannot be null");
        
        RuleFor(x => x.User)
            .MustAsync((user, cancellationToken) =>
            {
                var query = userRepository.Queryable.Where(x => x.Email == user.Email || x.Username == user.Username);
                return Task.FromResult(!query.Any());
            })
            .WithMessage("User exists yet");

    }
}