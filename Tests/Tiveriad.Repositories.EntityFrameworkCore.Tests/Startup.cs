using Faker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Tiveriad.IdGenerators;
using Tiveriad.Repositories.Tests.Models;
using Tiveriad.UnitTests;
using Xunit.Sdk;
using Company = Faker.Company;
using Enum = Faker.Enum;

namespace Tiveriad.Repositories.EntityFrameworkCore.Tests;

public class Startup : StartupBase
{
    private readonly int _maxRecord = 1000;

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
        var professorRepository = serviceProvider.GetRequiredService<ProfessorRepository>();
        var courseRepository = serviceProvider.GetRequiredService<CourseRepository>();
        var studentRepository = serviceProvider.GetRequiredService<StudentRepository>();

        for (var i = 0; i < 10; i++)
        {
            var professor = new Professor
            {
                Firstname = Name.First(),
                Lastname = Name.Last(),
                Email = Internet.Email()
            };

            professorRepository.AddOne(professor);

            courseRepository.AddOne(new Course<string>
            {
                Name = Company.Name(),
                Professor = professor
            });
        }

        for (var i = 0; i < _maxRecord; i++)
            studentRepository.AddOne(new Student<string>
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

    private void LoadInvoiceModel(IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetRequiredService<DbContext>();

        var companies = new List<Tiveriad.Repositories.Tests.Models.Company>();

        for (var i = 0; i < 100; i++)
        {
            var company = new Tiveriad.Repositories.Tests.Models.Company
            {
                Name = Company.Name(),
                City = Address.City(),
                Country = Address.Country(),
                StreetAddress = Address.StreetAddress()
            };
            companies.Add(company);
            serviceProvider?.GetService<CompanyRepository>()?.AddOne(company);
        }

        for (var i = 0; i < 30; i++)
        {
            var companyFrom = companies.AsQueryable().RandomElement(x => true);
            var toFrom = companies.AsQueryable().RandomElement(x => true);

            if (companyFrom == null)
                throw new NullException("companyFrom");

            if (toFrom == null)
                throw new NullException("toFrom");

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
            serviceProvider?.GetService<InvoiceRepository>()?.AddOne(invoice);
        }

        for (var i = 0; i < _maxRecord; i++)
            serviceProvider?.GetService<PersonRepository>()?.AddOne(new Person
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