using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Tiveriad.Repositories.EntityFrameworkCore.Tests.Models;

public sealed class DefaultContext : DbContext
{
    
    public DefaultContext(DbContextOptions<DefaultContext> options)
        : base(options)
    {
    }

    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseLoggerFactory(CreateEmptyLoggerFactory());
    }

    private static ILoggerFactory CreateEmptyLoggerFactory()
    {
        return LoggerFactory.Create(builder => builder
            .AddFilter((_, _) => false));
    }

    private static ILoggerFactory CreateLoggerFactory()
    {
        return LoggerFactory.Create(builder => builder
            .AddFilter((category, level) => category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information)
            .AddConsole());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Party>(x =>
        {
            x.ToTable("T_Party").HasKey(k => k.Id);
            x.HasDiscriminator(b => b.PartyType)
             .HasValue<Person>("Person")
             .HasValue<Company>("Company");
        });
        modelBuilder.Entity<Invoice>(x =>
        {
            x.ToTable("T_Invoice").HasKey(k => k.Id);
            x.HasMany(p => p.InvoiceDetails).WithOne(p=>p.Invoice);
            x.HasOne(n => n.From);
            x.HasOne(n => n.To);
        });
        modelBuilder.Entity<InvoiceDetail>(x =>
        {
            x.ToTable("T_InvoiceDetail").HasKey(k => k.Id);
        });
        
        modelBuilder.Entity<Student>(x =>
        {
            x.ToTable("T_Student").HasKey(k => k.Id);
            x.HasMany(p => p.Courses).WithMany(p => p.Students).UsingEntity(j => j.ToTable("J_StudentSource"));
        });
        modelBuilder.Entity<Professor>(x =>
        {
            x.ToTable("T_Professor").HasKey(k => k.Id);
        });
        modelBuilder.Entity<Course>(x =>
        {
            x.ToTable("T_Course").HasKey(k => k.Id);
            x.HasOne(n => n.Professor);
        });


    }
}