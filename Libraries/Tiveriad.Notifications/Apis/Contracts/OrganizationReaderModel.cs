#region

#endregion

namespace Tiveriad.Notifications.Apis.Contracts;

public class SubjectReaderModel
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; } = null!;

    public string? Description { get; set; }

    public string State { get; set; } =null!;
}