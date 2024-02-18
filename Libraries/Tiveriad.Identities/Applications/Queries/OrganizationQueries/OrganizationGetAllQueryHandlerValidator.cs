#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.OrganizationQueries;

public class OrganizationGetAllQueryHandlerValidator : AbstractValidator<OrganizationGetAllQueryHandlerRequest>
{
    private IRepository<Organization, string> _repository;

    public OrganizationGetAllQueryHandlerValidator(IRepository<Organization, string> repository)
    {
        _repository = repository;
    }
}