#region

using Microsoft.EntityFrameworkCore;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Identity.Integration.Persistence;

public class DefaultContext : DbContext
{
    public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(User).Assembly);
    }
}