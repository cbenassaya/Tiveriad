
using System;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Identities.Apis.Contracts.UserContracts;
namespace Tiveriad.Identities.Apis.Contracts.OrganizationContracts;

public class OrganizationReaderModelContract
{


    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Logo { get; set; }
    public string? TimeZone { get; set; }
    public string? Domain { get; set; }
    public string? Description { get; set; }
    public OrganizationState? State { get; set; }
    public Metadata? Properties { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? Created { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }
    public UserReduceModelContract? Owner { get; set; }

}

