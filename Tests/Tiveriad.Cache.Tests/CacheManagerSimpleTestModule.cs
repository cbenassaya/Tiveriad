using Microsoft.Extensions.DependencyInjection;
using Tiveriad.Commons.Tests;
using Tiveriad.Repositories.MongoDb.Tests.Models;
using Tiveriad.UnitTests;
using Xunit;

namespace Tiveriad.Cache.Tests;

public class CacheManagerSimpleTestModule : TestBase<Startup>
{
    [Fact]
    public void AddTest()
    {
        var person = new Person
        {
            Id = Guid.NewGuid().ToString(),
            Firstname = "John",
            Lastname = "Doe",
            Email = "john.doe@gmail.com"
        };
        
        GetRequiredService<ICacheManager<object>>().AddOrUpdate(person.Id, person, x=>person);
        var result = GetRequiredService<ICacheManager<object>>().Get(person.Id);
        Assert.Equal(person.Id, ((Person)result).Id);
    }

    [Fact]
    public  async  void OnAddTest()
    {
        var result = false;
        GetRequiredService<ICacheManager<object>>().OnAdd += (sender, args) => { result = true; };
        await Task.Run(() =>
        {
            var person = new Person
            {
                Id = Guid.NewGuid().ToString(),
                Firstname = "John",
                Lastname = "Doe",
                Email = "john.doe@gmail.com"
            };

            GetRequiredService<ICacheManager<object>>().AddOrUpdate(person.Id, person, x => person);
        });
        Assert.True(result);
    }
}