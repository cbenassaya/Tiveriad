namespace Tiveriad.Repositories.MongoDb.Tests.Models;

public class Person : Party
{
    public string Firstname { get; set; } = null!;
    public string Lastname { get; set; } = null!;
    public string Email { get; set; } = null!;
}