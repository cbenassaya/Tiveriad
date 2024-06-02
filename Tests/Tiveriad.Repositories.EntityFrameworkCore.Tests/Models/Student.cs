using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Core.Abstractions.Services;

namespace Tiveriad.Repositories.EntityFrameworkCore.Tests.Models;

public class Student : IEntity<string>, IWithTenant<string>
{
    public string Firstname { get; set; } = null!;
    public string Lastname { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string StreetAddress { get; set; } = null!;
    public ICollection<Course> Courses { get; set; } = null!;
    public string? Id { get; set; }
    public string OrganizationId { get; set; }
    public Visibility Visibility { get; set; }
}

public class Professor : IEntity<string>
{
    public string Firstname { get; set; } = null!;
    public string Lastname { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Id { get; set; } = null!;
}