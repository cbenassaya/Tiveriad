using Microsoft.EntityFrameworkCore;

namespace Tiveriad.Repositories.EntityFrameworkCore
{
    public static class EntityFrameworkExtensions
    {
        public static DbContext DetectChangesLazyLoading(this DbContext context, bool enabled)
        {
            context.ChangeTracker.AutoDetectChangesEnabled = enabled;

            context.ChangeTracker.LazyLoadingEnabled = enabled;

            context.ChangeTracker.QueryTrackingBehavior =
                enabled ? QueryTrackingBehavior.TrackAll : QueryTrackingBehavior.NoTracking;

            return context;
        }
    }
}