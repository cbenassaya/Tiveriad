namespace Tiveriad.Repositories.Tests.Models;

public class Course<TKey> : IEntity<TKey>  where TKey : IEquatable<TKey>
{
    public string Name { get; set; } = null!;
    public Professor Professor { get; set; } = null!;
    public ICollection<Student<TKey>> Students { get; set; } = null!;
    public TKey Id { get; set; } = default(TKey)!;

    protected bool Equals(Course<TKey> other)
    {
        return Id.Equals(other.Id);
    }
}