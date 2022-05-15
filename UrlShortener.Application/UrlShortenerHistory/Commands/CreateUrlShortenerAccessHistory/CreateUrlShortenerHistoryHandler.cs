using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UrlShortener.Application.Mappers;
using UrlShortener.Domain.Model;

namespace UrlShortener.Application.Content.UrlShortenerHistory.Commands.CreateUrlShortenerAccessHistory
{
    internal class CreateUrlShortenerHistoryHandler : IRequestHandler<CreateUrlShortenerHistoryRequest, CreateUrlShortenerHistoryResult>
    {
        private readonly IUrlShortenerHistoryRepository _urlShortenerHistoryRepository;

        public CreateUrlShortenerHistoryHandler(IUrlShortenerHistoryRepository urlShortenerHistoryRepository)
        {
            _urlShortenerHistoryRepository = urlShortenerHistoryRepository;
        }

        public async Task<CreateUrlShortenerHistoryResult> Handle(CreateUrlShortenerHistoryRequest request, CancellationToken cancellationToken)
        {
            var urlShortenerHistoryEnity = UrlShortenerHistoryMapper.Map(request);
            var id = await _urlShortenerHistoryRepository.Add(urlShortenerHistoryEnity);

            return new CreateUrlShortenerHistoryResult()
            {
                Id = id,
                UrlShortenerId = request.UrlShortenerId
            };
        }
    }
}
