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
        Task<long> Add(UrlShortenerHistoryEnity urlShortenerHistory);
        Task<UrlShortenerHistoryEnity> Get(long id);
        IQueryable<UrlShortenerHistoryEnity> GetAll();
    }
}
