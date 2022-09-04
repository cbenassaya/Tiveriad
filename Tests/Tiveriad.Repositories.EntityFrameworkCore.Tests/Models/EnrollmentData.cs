namespace Tiveriad.Repositories.EntityFrameworkCore.Tests.Models;

internal class EnrollmentData
{
    public long StudentId { get; set; }
    public int Grade { get; set; }
    public string Course { get; set; } = null!;
}
