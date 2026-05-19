using Arkitektur.Entity.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.DataAccess.Interceptors
{
    public class AuditDbContextInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            foreach (var entry in eventData.Context.ChangeTracker.Entries())
            {
                if (entry.Entity is BaseEntity baseEntity)
                {
                    if (entry.State == EntityState.Added)
                    {
                        baseEntity.CreatedDate = DateTime.Now;
                        baseEntity.UpdatedDate = DateTime.Now;
                    }
                    else if (entry.State == EntityState.Modified)
                    {
                        baseEntity.UpdatedDate = DateTime.Now;
                    }
                    else if(entry.State == EntityState.Deleted)
                    {
                        baseEntity.IsDeleted = true;
                        entry.State = EntityState.Modified; // Mark as modified to update the IsDeleted flag
                    }
                }
            }
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
