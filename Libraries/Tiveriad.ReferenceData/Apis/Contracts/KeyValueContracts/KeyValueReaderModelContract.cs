
using System;
using Tiveriad.Core.Abstractions.Entities;
using System.Collections.Generic;
using Tiveriad.ReferenceData.Apis.Contracts.InternationalizedValueContracts;
namespace Tiveriad.ReferenceData.Apis.Contracts.KeyValueContracts;

public class KeyValueReaderModelContract
{
    public string? Id { get; set; }
    public string? Key { get; set; }
    public string? Entity { get; set; }
    public string? ImageUrl { get; set; }
    public Metadata? Properties { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? Created { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }
    public string Value  { get; set; } = default!;
    public List<InternationalizedValueModelContract> InternationalizedValues  { get; set; } = new();

}

