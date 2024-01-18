using Tiveriad.Multitenancy.Core.Entities;

namespace Tiveriad.Multitenancy.Apis.Contracts;
public class OrganizationReaderModel
{
    public string? Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public OrganizationState? State { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? Created { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModified { get; set; }
}