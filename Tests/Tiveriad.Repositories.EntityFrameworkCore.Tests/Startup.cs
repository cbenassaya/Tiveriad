#region

using Faker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Core.Abstractions.Services;
using Tiveriad.IdGenerators;
using Tiveriad.Repositories.EntityFrameworkCore.Repositories;
using Tiveriad.Repositories.EntityFrameworkCore.Tests.Models;
using Tiveriad.Repositories.Microsoft.DependencyInjection;
using Tiveriad.UnitTests;
using Xunit.Sdk;
using Company = Faker.Company;
using Enum = Faker.Enum;

#endregion

namespace Tiveriad.Repositories.EntityFrameworkCore.Tests;

public class Startup : StartupBase
{
    private readonly int _maxRecord = 1000;

    public override void Configure(IServiceCollection services)
    {
        services.AddDbContext<DbContext, DefaultContext>((provider, options) =>
        {
            var logger = provider.GetService<ILogger<Startup>>();
            options.UseSqlite("Data Source=tests.db");
            options.EnableSensitiveDataLogging();
            options.EnableDetailedErrors();
            if (logger != null)
                options.LogTo(message => { logger.LogInformation(message); }, LogLevel.Information);
        });
        services.AddScoped<ITenantService<string>, TenantService>();
        services.AddRepositories(typeof(EFRepository<,>), typeof(Course));
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
        var professorRepository = serviceProvider.GetRequiredService<IRepository<Professor, string>>();
        var courseRepository = serviceProvider.GetRequiredService<IRepository<Course, string>>();
        var studentRepository = serviceProvider.GetRequiredService<IRepository<Student, string>>();

        for (var i = 0; i < 10; i++)
        {
            var professor = new Professor
            {
                Firstname = Name.First(),
                Lastname = Name.Last(),
                Email = Internet.Email()
            };

            professorRepository.AddOne(professor);

            courseRepository.AddOne(new Course
            {
                Name = Company.Name(),
                Professor = professor
            });
        }

        for (var i = 0; i < _maxRecord; i++)
            studentRepository.AddOne(new Student
            {
                Firstname = Name.First(),
                Lastname = Name.Last(),
                Email = Internet.Email(),
                City = Address.City(),
                Country = Address.Country(),
                StreetAddress = Address.StreetAddress(),
                OrganizationId = "1",
                Visibility = Visibility.Private
            });
        context.SaveChanges();
    }

    private void LoadInvoiceModel(IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetRequiredService<DbContext>();

        var companies = new List<Models.Company>();

        for (var i = 0; i < 100; i++)
        {
            var company = new Models.Company
            {
                Name = Company.Name(),
                City = Address.City(),
                Country = Address.Country(),
                StreetAddress = Address.StreetAddress()
            };
            companies.Add(company);
            serviceProvider?.GetService<IRepository<Models.Company, string>>()?.AddOne(company);
        }

        for (var i = 0; i < 30; i++)
        {
            var companyFrom = companies.AsQueryable().RandomElement(x => true);
            var toFrom = companies.AsQueryable().RandomElement(x => true);

            if (companyFrom == null)
                NullException.ForNonNullValue("companyFrom");

            if (toFrom == null)
                NullException.ForNonNullValue("toFrom");

            var invoice = new Invoice
            {
                InvoiceState = Enum.Random<InvoiceState>(),
                From = companyFrom,
                To = toFrom
            };
            invoice.InvoiceDetails = new List<InvoiceDetail>
            {
                new()
                    { Amount = Finance.Coupon(), Label = Finance.Credit.BondName(), Id = KeyGenerator.NewId<string>() },
                new()
                    { Amount = Finance.Coupon(), Label = Finance.Credit.BondName(), Id = KeyGenerator.NewId<string>() },
                new()
                    { Amount = Finance.Coupon(), Label = Finance.Credit.BondName(), Id = KeyGenerator.NewId<string>() }
            };
            serviceProvider?.GetService<IRepository<Invoice, string>>()?.AddOne(invoice);
        }

        for (var i = 0; i < _maxRecord; i++)
            serviceProvider?.GetService<IRepository<Person, string>>()?.AddOne(new Person
            {
                Firstname = Name.First(),
                Lastname = Name.Last(),
                Email = Internet.Email(),
                City = Address.City(),
                Country = Address.Country(),
                StreetAddress = Address.StreetAddress()
            });

        context.SaveChanges();
    }
    
    
}

public class TenantService : ITenantService<string>
{
    public string TenantId {get; set;} ="1";
    public string GetTenantId()
    {
        return TenantId;
    }
}