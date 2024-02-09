
using System;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Core.Abstractions.Entities;
using System.ComponentModel.DataAnnotations;
namespace Tiveriad.Identities.Apis.Contracts.OrganizationContracts;

public class OrganizationWriterModelContract
{


    public string? Name { get; set; }
    public string? Logo { get; set; }
    public string? Domain { get; set; }
    public string? Description { get; set; }
    public OrganizationState? State { get; set; }
    public Metadata? Properties { get; set; }
    [Required] public string OwnerId { get; set; } = default!;
    [Required] public string TimeAreaId { get; set; } = default!;

}

