namespace Tiveriad.Repositories.Tests.Models;

public class Student<TKey> : IEntity<TKey>  where TKey : IEquatable<TKey>
{
    public string Firstname { get; set; } = null!;
    public string Lastname { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string StreetAddress { get; set; } = null!;
    public ICollection<Course<TKey>> Courses { get; set; } = null!;
    public TKey Id { get; set; } = default(TKey)!;
}

public class Professor : IEntity<string>
{
    public string Firstname { get; set; } = null!;
    public string Lastname { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Id { get; set; } = null!;
}