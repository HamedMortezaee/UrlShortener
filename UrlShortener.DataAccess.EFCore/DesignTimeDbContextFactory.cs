using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.DataAccess.EFCore;

namespace WorkflowRMRC.Gateways.RestApi
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<UrlShortenerDbContext>
    {
        public UrlShortenerDbContext CreateDbContext(string[] args)
        {

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<UrlShortenerDbContext>();
            var connectionString = configuration.GetConnectionString("UrlShortenerApiDB");
            builder.UseSqlServer(connectionString);
            return new UrlShortenerDbContext(builder.Options);
        }
    }
}
