using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UrlShortener.Domain.Model;

namespace UrlShortener.Application.Content.UrlShortener.Queries
{
    public class UrlShortenerItemQueryHandler : IRequestHandler<UrlShortenerItemQuery, UrlShortenerItemResultQuery>
    {
        private readonly IUrlShortenerRepository _urlShortenerRepository;

        public UrlShortenerItemQueryHandler(IUrlShortenerRepository urlShortenerRepository)
        {
            _urlShortenerRepository = urlShortenerRepository;
        }

        public async Task<UrlShortenerItemResultQuery> Handle(UrlShortenerItemQuery request, CancellationToken cancellationToken)
        {
            var urlShortenerEnity =
                await _urlShortenerRepository.GetByurlShortenerGUID(request.UrlShortenerGUID);
            if (urlShortenerEnity == null)
                throw new Exception("آدرس موردنظر موجود نمی باشد");
            return new UrlShortenerItemResultQuery()
            {
                Id = urlShortenerEnity.Id,
                MainUrl = urlShortenerEnity.MainUrl,
                ShortestUrl = urlShortenerEnity.ShortestUrl
            };
        }
    }
}
