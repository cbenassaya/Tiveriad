
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
    public string Value  { get; set; } = default!;
    public string Language  { get; set; } = default!;
    public string Visibility  { get; set; } = default!;
}

public class KeyInternationalizedValueReaderModelContract
{
    public string? Id { get; set; }
    public string? Key { get; set; }
    public string? Entity { get; set; }
    public string? ImageUrl { get; set; }
    public Metadata? Properties { get; set; }
    public List<InternationalizedValueModelContract> InternationalizedValues  { get; set; } = new();
}

public class KeyValueReaderModel
{
    public string? Id { get; set; }
    public string? Key { get; set; }
    public string? Entity { get; set; }
    public string? ImageUrl { get; set; }
    public Metadata? Properties { get; set; }
    public List<InternationalizedValueModelContract> InternationalizedValues  { get; set; } = new();
    public string Value  { get; set; } = default!;
    public string Language  { get; set; } = default!;
}


