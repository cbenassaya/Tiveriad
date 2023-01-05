using MongoDB.Bson;
using Tiveriad.Repositories.MongoDb.Tests.Models;
using Tiveriad.UnitTests;
using Xunit;
using Company = Faker.Company;

namespace Tiveriad.Repositories.MongoDb.Tests;

public class RepositoryTest  : TestBase<Startup>
{
    
    [Fact]
    public async Task Add_Entity()
    {
        var repository = GetService<IRepository<Course, ObjectId>>();
        var name = Company.Name();
        var course = new Course { Name = name};
        await repository.AddOneAsync(course);
        var items = await repository.FindAsync(x => x.Name.Equals(name));
        Assert.Equal(1,items.Count());
    }
}