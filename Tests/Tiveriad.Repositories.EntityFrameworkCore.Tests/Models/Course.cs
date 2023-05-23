namespace Tiveriad.Repositories.EntityFrameworkCore.Tests.Models;

public class Course : IEntity<string>
{
    public string Name { get; set; } = null!;
    public Professor Professor { get; set; } = null!;
    public ICollection<Student> Students { get; set; } = null!;
    public string Id { get; set; }

    protected bool Equals(Course other)
    {
        return Id.Equals(other.Id);
    }
}