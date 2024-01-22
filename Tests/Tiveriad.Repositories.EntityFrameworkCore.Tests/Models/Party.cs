using Tiveriad.Core.Abstractions.Entities;

namespace Tiveriad.Repositories.EntityFrameworkCore.Tests.Models;

public class Party : IEntity<string>
{
    public string PartyType { get; set; } = null!;

    public string City { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string StreetAddress { get; set; } = null!;
    public string? Id { get; set; } = null!;
}