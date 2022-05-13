using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.DataAccess.EFCore.Mapping;
using UrlShortener.Domain.Model;

namespace UrlShortener.DataAccess.EFCore
{
    public class UrlShrtenerDbContext : DbContext
    {
        public DbSet<UrlShortenerEnity> UrlShortenerEnity { get; set; }
        public DbSet<UrlShortenerHistoryEnity> UrlShortenerHistoryEnity { get; set; }

        public UrlShrtenerDbContext(DbContextOptions<UrlShrtenerDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UrlShortenerMapping());
            modelBuilder.ApplyConfiguration(new UrlShortenerMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
