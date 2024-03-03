
using System;
using Tiveriad.Core.Abstractions.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tiveriad.ReferenceData.Apis.Contracts.InternationalizedValueContracts;

namespace Tiveriad.ReferenceData.Apis.Contracts.KeyValueContracts;

public class KeyValueWriterModelContract
{
    [Required] public string Key { get; set; } = default!;
    public string? ImageUrl { get; set; }
    public Metadata? Properties { get; set; }
    [Required] public List<InternationalizedValueModelContract> InternationalizedValues { get; set; } = new();

}

