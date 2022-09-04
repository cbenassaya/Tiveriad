namespace Tiveriad.Repositories.EntityFrameworkCore.Tests.Models;

public class Student:IEntity<int>
{
    public int Id { get; set; }
    public string Firstname { get; set; }= null!;
    public string Lastname { get; set; }= null!;
    public string Email { get; set; }= null!;
    public string City { get; set; }= null!;
    public string Country { get; set; }= null!;
    public string StreetAddress { get; set; }= null!;
    public ICollection<Course> Courses { get; set; }= null!;
}


public class Professor : IEntity<int>
{
    public int Id { get; set; }
    public string Firstname { get; set; }= null!;
    public string Lastname { get; set; }= null!;
    public string Email { get; set; }= null!;
}
