#region

using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Tiveriad.Documents.Core.Entities;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Notifications.Core.Entities;

#endregion

namespace Tiveriad.Integration.Persistence;

public class DefaultContext : DbContext
{
    public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DocumentDescription).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Notification).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(User).Assembly);
    }
}