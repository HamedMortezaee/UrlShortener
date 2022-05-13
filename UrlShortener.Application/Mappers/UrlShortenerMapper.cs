using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Application.Content.UrlShortener.Commands.CreateUrlShortener;
using UrlShortener.Domain.Model;

namespace UrlShortener.Application.Mappers
{
    public static  class UrlShortenerMapper
    {
        public static UrlShortenerEnity Map(CreateUrlShortener entity)
        {
            if (entity == null) return null;
            var ulShortenerGUID = Guid.NewGuid().ToString();
            var urlShortenerEnity = new UrlShortenerEnity(
                ulShortenerGUID, entity.MainUrl, entity.ShortestUrl
            );
            return urlShortenerEnity;
        }
    }
}
