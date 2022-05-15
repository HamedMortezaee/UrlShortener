using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UrlShortener.DataAccess.EFCore.Mapping;
using UrlShortener.Domain.Common;
using UrlShortener.Domain.Model;

namespace UrlShortener.DataAccess.EFCore
{
    public class UrlShortenerDbContext : DbContext, IUrlShortenerDbContext
    {
        public DbSet<UrlShortenerEnity> UrlShortenerEnity { get; set; }
        public DbSet<UrlShortenerHistoryEnity> UrlShortenerHistoryEnity { get; set; }

        public UrlShortenerDbContext(DbContextOptions<UrlShortenerDbContext> options) : base(options)
        {

        }

        //public UrlShortenerDbContext(DbContextOptions options) : base(options)
        //{
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UrlShortenerMapping());
            modelBuilder.ApplyConfiguration(new UrlShortenerMapping());
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<EventLog>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.RegisterDate = DateTime.Now;
                        entry.Entity.RegisterUserId = Guid.NewGuid().ToString();
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdateDate = DateTime.Now;
                        entry.Entity.UpdateUserId = Guid.NewGuid().ToString();
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
