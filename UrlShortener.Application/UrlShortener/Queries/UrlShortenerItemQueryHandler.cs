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
    public class UrlShortenerItemQueryHandler : IRequestHandler<UrlShortenerItemRequestQuery, UrlShortenerItemResultQuery>
    {
        private readonly IUrlShortenerRepository _urlShortenerRepository;
        private readonly IUrlShortenerHistoryRepository _urlShortenerHistoryRepository;

        public UrlShortenerItemQueryHandler(IUrlShortenerRepository urlShortenerRepository, 
                                                IUrlShortenerHistoryRepository urlShortenerHistoryRepository)
        {
            _urlShortenerRepository = urlShortenerRepository;
            _urlShortenerHistoryRepository = urlShortenerHistoryRepository;
        }

        public async Task<UrlShortenerItemResultQuery> Handle(UrlShortenerItemRequestQuery request, CancellationToken cancellationToken)
        {
            var urlShortenerEnity = _urlShortenerRepository.GetByurlShortenerGUID(request.UrlShortener).Result;
            if (urlShortenerEnity == null)
                throw new Exception("آدرس موردنظر موجود نمی باشد");


            var urlShortenerHistory = new UrlShortenerHistoryEnity(urlShortenerEnity.Id);
            await _urlShortenerHistoryRepository.Add(urlShortenerHistory);

            return new UrlShortenerItemResultQuery()
            {
                Id = urlShortenerEnity.Id,
                MainUrl = urlShortenerEnity.MainUrl,
                ShortestUrl = urlShortenerEnity.ShortestUrl
            };
        }
    }
}
