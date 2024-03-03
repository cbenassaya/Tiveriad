#region

using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Tiveriad.ReferenceData.Core.Entities;

#endregion

namespace ReferenceData.Integration.Persistence;

public class DefaultContext : DbContext
{
    public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(KeyValue).Assembly);
    }
}