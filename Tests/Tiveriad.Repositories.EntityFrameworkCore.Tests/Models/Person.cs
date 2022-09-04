namespace Tiveriad.Repositories.EntityFrameworkCore.Tests.Models;

public class Person:Party
{
    public string Firstname { get; set; }
    
    public string Lastname { get; set; }
    public string Email { get; set; }
}