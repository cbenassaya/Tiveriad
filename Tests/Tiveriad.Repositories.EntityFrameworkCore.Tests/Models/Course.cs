namespace Tiveriad.Repositories.EntityFrameworkCore.Tests.Models;

public class Course : IEntity<string>
{
    public string Name { get; set; } = null!;
    public Professor Professor { get; set; } = null!;
    public ICollection<Student> Students { get; set; } = null!;
    public string Id { get; set; } = null!;

    protected bool Equals(Course other)
    {
        return Id == other.Id;
    }
}