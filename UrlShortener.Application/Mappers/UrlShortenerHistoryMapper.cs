using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Application.Content.UrlShortenerHistory.Commands.CreateUrlShortenerAccessHistory;
using UrlShortener.Domain.Model;

namespace UrlShortener.Application.Mappers
{
    public static class UrlShortenerHistoryMapper
    {
        public static UrlShortenerHistoryEnity Map(CreateUrlShortenerHistoryRequest entity)
        {
            if (entity == null) return null;
            var ulShortenerGUID = Guid.NewGuid().ToString();
            var urlShortenerHistoryEnity = new UrlShortenerHistoryEnity(
                entity.UrlShortenerId
            );
            return urlShortenerHistoryEnity;
        }
    }
}
