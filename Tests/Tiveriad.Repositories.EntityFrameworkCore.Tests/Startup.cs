using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Tiveriad.Commons.Tests;
using Tiveriad.Repositories.EntityFrameworkCore.Repositories;
using Tiveriad.Repositories.EntityFrameworkCore.Tests.Models;

namespace Tiveriad.Repositories.EntityFrameworkCore.Tests;

public class Startup : StartupBase
{
    private int _maxRecord = 1000;
    public override void Configure(IServiceCollection services)
    {
        services.AddDbContext<DbContext, DefaultContext>(options =>
        {
            options.UseSqlite("Data Source=tests.db");
            options.EnableSensitiveDataLogging();
            options.EnableDetailedErrors();
            options.LogTo(Console.WriteLine, LogLevel.Information);
        });

        services.AddScoped<CourseRepository>();
        services.AddScoped<StudentRepository>();
        services.AddScoped<CompanyRepository>();
        services.AddScoped<PersonRepository>();
        services.AddScoped<InvoiceRepository>();
        services.AddScoped<ProfessorRepository>();
    }
    public override void Init(IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetRequiredService<DbContext>();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        LoadStudentModel(serviceProvider);
        LoadInvoiceModel(serviceProvider);
    }
    private void LoadStudentModel(IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetRequiredService<DbContext>();
        
        for (var i = 0; i < 10; i++)
        {

            var professor = new Professor()
            {
                Firstname = Faker.Name.First(),
                Lastname = Faker.Name.Last(),
                Email = Faker.Internet.Email()
            };
            
            serviceProvider.GetService<ProfessorRepository>( ).AddOne(professor);
            
            serviceProvider.GetService<CourseRepository>( ).AddOne(new Course
            {
                Name = Faker.Company.Name(),
                Professor = professor
            });
        }
        

        for (var i = 0;  i < _maxRecord; i++)
        {
            serviceProvider.GetService<StudentRepository>( ).AddOne(new Student()
            {
                Firstname = Faker.Name.First(),
                Lastname = Faker.Name.Last(),
                Email = Faker.Internet.Email(),
                City = Faker.Address.City(),
                Country = Faker.Address.Country(),
                StreetAddress = Faker.Address.StreetAddress()
            });
        }
        context.SaveChanges();
    }
    private void LoadInvoiceModel(IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetRequiredService<DbContext>();

        var companies = new List<Company>();

        for (var i = 0; i < 100; i++)
        {
            var company = new Company()
            {
                Name = Faker.Company.Name(),
                City = Faker.Address.City(),
                Country = Faker.Address.Country(),
                StreetAddress = Faker.Address.StreetAddress()
            };
            companies.Add(company);
            serviceProvider.GetService<CompanyRepository>( ).AddOne(company);
            
        }
      

        for (var i = 0; i < _maxRecord; i++)
        {
            var invoice = new Invoice()
            {
                InvoiceState = Faker.Enum.Random<InvoiceState>(),
                From = companies.AsQueryable().RandomElement<Company>(x => true),
                To = companies.AsQueryable().RandomElement<Company>(x => true)
            };
            invoice.InvoiceDetails = new List<InvoiceDetail>
            {
                new()
                    { Amount = Faker.Finance.Coupon(), Label = Faker.Finance.Credit.BondName() },
                new()
                    { Amount = Faker.Finance.Coupon(), Label = Faker.Finance.Credit.BondName() },
                new()
                    { Amount = Faker.Finance.Coupon(), Label = Faker.Finance.Credit.BondName() }
            };
            serviceProvider.GetService<InvoiceRepository>( ).AddOne(invoice);
        }

        for (var i = 0; i < _maxRecord; i++)
        {
            serviceProvider.GetService<PersonRepository>().AddOne(new Person()
            {
                Firstname = Faker.Name.First(),
                Lastname = Faker.Name.Last(),
                Email = Faker.Internet.Email(),
                City = Faker.Address.City(),
                Country = Faker.Address.Country(),
                StreetAddress = Faker.Address.StreetAddress()
            });
        }

        context.SaveChanges();
    }
}

