#region

using Tiveriad.Workflows.Core.Services;

#endregion

namespace Tiveriad.Workflows.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime Now => DateTime.Now;
    public DateTime UtcNow => DateTime.UtcNow;
}