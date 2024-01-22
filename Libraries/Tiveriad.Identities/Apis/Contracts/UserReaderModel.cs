namespace Tiveriad.Identities.Apis.Contracts;

public class UserReaderModel
{
    public string? Id { get; set; }

    public string? Email { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? Description { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? Created { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModified { get; set; }
}