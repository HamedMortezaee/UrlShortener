using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UrlShortener.Domain.Model;

namespace UrlShortener.DataAccess.EFCore
{
    public interface IUrlShortenerDbContext : IDisposable
    {
        DbSet<UrlShortenerEnity> UrlShortenerEnity { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
