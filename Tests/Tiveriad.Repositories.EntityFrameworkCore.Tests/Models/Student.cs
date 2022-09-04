namespace Tiveriad.Repositories.EntityFrameworkCore.Tests.Models;

public class Student:IEntity<int>
{
    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string StreetAddress { get; set; }
    public ICollection<Course> Courses { get; set; }
}


public class Professor : IEntity<int>
{
    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
}
