using System.Globalization;
using Microsoft.Extensions.DependencyInjection;
using Tiveriad.UnitTests;
using Xunit;

namespace Tiveriad.Repositories.Tests;

public class Startup : StartupBase
{
    public override void Configure(IServiceCollection services)
    {
    }
}


public class InternationalizedTest : TestBase<Startup>
{
    [Fact]
    public async void MultiCultureInfoTest()
    {
        var data = await  Task<bool>.Run(() =>
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");
            InternationalizedString test= "Bonjour";
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            test.SetValue("Hello");
            Thread.CurrentThread.CurrentCulture = new CultureInfo("tr-TR");
            test.SetValue("Merhaba");
            Thread.CurrentThread.CurrentCulture = new CultureInfo("it-IT");
            test.SetValue("Ciao");
            Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");
            test.SetValue("Hallo");
            
            bool result = test == "Hallo";
            Thread.CurrentThread.CurrentCulture = new CultureInfo("it-IT");
            result = result && test == "Ciao";
            Thread.CurrentThread.CurrentCulture = new CultureInfo("tr-TR");
            result = result && test == "Merhaba";
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            result = result && test == "Hello";
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");
            result = result && test == "Bonjour";
            return result;
        });
        
        Assert.True(data);
    }

    [Fact]
    public async void WithoutCultureInfoTest()
    {
        var data = await  Task<bool>.Run(() =>
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");
            InternationalizedString test= "Bonjour";
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            test.SetValue("Hello");
            Thread.CurrentThread.CurrentCulture = new CultureInfo("it-IT");
            bool result = test == "";
            return result;
        });
    }
    
}
