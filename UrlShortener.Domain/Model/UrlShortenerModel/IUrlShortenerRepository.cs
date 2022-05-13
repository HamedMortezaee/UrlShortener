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
        Task<long> Add(UrlShortenerEnity urlShortener);
        Task Edit(UrlShortenerEnity urlShortener);
        Task<UrlShortenerEnity> Get(long id);
        Task<UrlShortenerEnity> GetByurlShortenerGUID(string urlShortenerGUID);
    }
}
