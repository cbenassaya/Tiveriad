namespace Tiveriad.Repositories.EntityFrameworkCore.Tests.Models;

public class Party:IEntity<int>
{
    public int Id { get; set; }
    public string PartyType { get; set; }
    
    public string City { get; set; }
    public string Country { get; set; }
    public string StreetAddress { get; set; }
}