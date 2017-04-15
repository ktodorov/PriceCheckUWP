using Microsoft.EntityFrameworkCore;
using PriceCheck.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading;

namespace PriceCheck.Data.Context
{
    public class PriceCheckContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<PriceChange> PriceChanges { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=priceCheck.db");
        }

        public override Task<EntityEntry> AddAsync(object entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            var entityBase = entity as EntityBase;
            if (entityBase != null && entityBase.Id == 0)
            {
                entityBase.DateCreated = DateTime.Now;
                entityBase.DateModified = DateTime.Now;
            }

            return base.AddAsync(entity, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            DateTime saveTime = DateTime.UtcNow;

            var addedEntries = this.ChangeTracker.Entries().Where(e => e.State == EntityState.Added);
            foreach (var entry in addedEntries)
            {
                entry.Property("DateCreated").CurrentValue = saveTime;
                entry.Property("DateModified").CurrentValue = saveTime;
            }

            var modifiedEntries = this.ChangeTracker.Entries().Where(e => e.State == EntityState.Modified);
            foreach (var entry in modifiedEntries)
            {
                entry.Property("DateModified").CurrentValue = saveTime;
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
