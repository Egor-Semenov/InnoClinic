using Domain.Interfaces.SoftDelete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infrastructure.Persistence.Interceptors
{
    public sealed class SoftDeleteInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            if (eventData.Context is null)
            {
                return new ValueTask<InterceptionResult<int>>(result);
            }

            var entries = eventData.Context.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Deleted && e.Entity is ISoftDelete);

            foreach (var entry in entries)
            {
                entry.State = EntityState.Modified;
                if (entry.Entity is ISoftDelete softDeleteEntity)
                {
                    softDeleteEntity.IsDeleted = true;
                    softDeleteEntity.DeletedAt = DateTimeOffset.UtcNow;
                }
            }

            return new ValueTask<InterceptionResult<int>>(result);
        }
    }
}
