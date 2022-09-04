namespace Tiveriad.Repositories.EntityFrameworkCore.Tests.Models;

public class Party:IEntity<int>
{
    public int Id { get; set; }
    public string PartyType { get; set; }= null!;
    
    public string City { get; set; }= null!;
    public string Country { get; set; }= null!;
    public string StreetAddress { get; set; }= null!;
}