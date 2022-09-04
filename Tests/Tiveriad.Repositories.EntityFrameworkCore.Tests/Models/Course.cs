namespace Tiveriad.Repositories.EntityFrameworkCore.Tests.Models;

public class Course:IEntity<int>
{
    protected bool Equals(Course other)
    {
        return Id == other.Id;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Course)obj);
    }

    public override int GetHashCode()
    {
        return Id;
    }

    public static bool operator ==(Course? left, Course? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Course? left, Course? right)
    {
        return !Equals(left, right);
    }

    public int Id { get; set; }
    public string Name { get; set; }= null!;
    public Professor Professor  { get; set; }= null!;
    public ICollection<Student> Students { get; set; }= null!;
}