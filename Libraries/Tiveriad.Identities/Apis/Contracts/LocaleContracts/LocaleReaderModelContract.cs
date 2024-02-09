
using System;
namespace Tiveriad.Identities.Apis.Contracts.LocaleContracts;

public class LocaleReaderModelContract
{


    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Code { get; set; }
    public string? Descriptions { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? Created { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }

}

