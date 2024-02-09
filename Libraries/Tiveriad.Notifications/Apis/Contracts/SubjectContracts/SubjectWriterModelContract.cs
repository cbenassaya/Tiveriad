
using System;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Notifications.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Tiveriad.Notifications.Apis.Contracts.SubjectContracts;

public class SubjectWriterModelContract
{


    public string? Name { get; set; }
    public InternationalizedString? Description { get; set; }
    public SubjectState? State { get; set; }
    [Required] public string TemplateId { get; set; } = default!;
    [Required] public List<string> ScopesId { get; set; } = new();

}

