using Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Domain.Model
{
    public interface IUrlShortenerHistoryRepository : IRepository
    {
        Task<long> Add(UrlShortenerHistory urlShortenerHistory);
        Task Edit(UrlShortenerHistory urlShortenerHistory);
        Task<UrlShortenerHistory> Get(long billDetailInfo);
        IQueryable<UrlShortener> GetAll();
    }
}
