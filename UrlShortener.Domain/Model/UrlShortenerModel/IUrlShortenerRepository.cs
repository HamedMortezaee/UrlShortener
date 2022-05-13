using Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Domain.Model
{
    public interface IUrlShortenerRepository : IRepository
    {
        Task<long> Add(UrlShortener urlShortener);
        Task Edit(UrlShortener urlShortener);
        Task<UrlShortener> Get(long billDetailInfo);
        IQueryable<UrlShortener> GetAll();
    }
}
