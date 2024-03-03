
using System;
using System.ComponentModel.DataAnnotations;

namespace Tiveriad.ReferenceData.Apis.Contracts.InternationalizedValueContracts;

public class InternationalizedValueModelContract
{
    [Required] public string Language { get; set; } = default!;
    [Required] public string Value { get; set; } = default!;
    [Required] public bool Default { get; set; }
}

