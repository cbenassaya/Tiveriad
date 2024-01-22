using System.Globalization;
using Microsoft.Extensions.DependencyInjection;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Repositories.Tests.Models;
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
    
    
    [Fact]
    public async void TransformationToDtoTest()
    {
        var book = await  Task<Book>.Run(() =>
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");
            Book book = new Book();
            book.Title = "Bonjour";
            return book;
        });
        
        var bookModel = await  Task<BookModel>.Run(() =>
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");
            var model = new BookModel()
            {
                Title = book.Title
            };
            return model;
        });


       
        Assert.Equal("Bonjour", bookModel.Title);
    }
    
    [Fact]
    public async void TransformationListToDtoListTest()
    {
        var books = await  Task<List<Book>>.Run(() =>
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");
            List<Book> books = new List<Book>();
            books.Add(new ()
            {
                Title = "Bonjour"
            });
            books.Add(new ()
            {
                Title = "Bonjour"
            });
            books.Add(new ()
            {
                Title = "Bonjour"
            });
            books.Add(new ()
            {
                Title = "Bonjour"
            });
            return books;
        });
        
        var bookModels = await  Task<List<BookModel>>.Run(() =>
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");
            var models =books.Select(book => new BookModel()
            {
                Title = book.Title
            }).ToList();
            
            return models;
        });


       
        Assert.Equal("Bonjour", bookModels.First().Title);
    }

    
}
