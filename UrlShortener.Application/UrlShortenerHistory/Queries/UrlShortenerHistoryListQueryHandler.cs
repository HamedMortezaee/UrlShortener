using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UrlShortener.Domain.Model;

namespace UrlShortener.Application.UrlShortenerHistory.Queries
{
    public class UrlShortenerHistoryListQueryHandler : IRequestHandler<UrlShortenerHistoryListRequestQuery, UrlShortenerHistoryListResultQuery>
    {
        private readonly IUrlShortenerHistoryRepository _urlShortenerHistoryRepository;

        public UrlShortenerHistoryListQueryHandler(IUrlShortenerHistoryRepository urlShortenerHistoryRepository)
        {
            _urlShortenerHistoryRepository = urlShortenerHistoryRepository;
        }

        public async Task<UrlShortenerHistoryListResultQuery> Handle(UrlShortenerHistoryListRequestQuery request, CancellationToken cancellationToken)
        {
            var urlShortenerEnitys =
                await _urlShortenerHistoryRepository.GetByFilter(request.StartDate, request.EndDate, request.ShortUrl);

            return new UrlShortenerHistoryListResultQuery()
            {
                StartDate = request.StartDate,
                EndDate = request.EndDate,  
                CallShortUrlCount = urlShortenerEnitys.Count
            };
        }
    }
}
