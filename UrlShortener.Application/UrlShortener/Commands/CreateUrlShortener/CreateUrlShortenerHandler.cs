using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UrlShortener.Application.Mappers;
using UrlShortener.Domain.Model;

namespace UrlShortener.Application.Content.UrlShortener.Commands.CreateUrlShortener
{
    public class CreateUrlShortenerHandler : IRequestHandler<CreateUrlShortener, CreateUrlShortenerResult>
    {
        private readonly IUrlShortenerRepository _urlShortenerRepository;

        public CreateUrlShortenerHandler(IUrlShortenerRepository urlShortenerRepository)
        {
            _urlShortenerRepository = urlShortenerRepository;
        }

        public async Task<CreateUrlShortenerResult> Handle(CreateUrlShortener request, CancellationToken cancellationToken)
        {
            request.ShortestUrl = "";
            var urlShortener = UrlShortenerMapper.Map(request);
            var id = await _urlShortenerRepository.Add(urlShortener);
            return new CreateUrlShortenerResult()
            {
                Id = id,
                MainUrl = request.MainUrl,
                ShortestUrl = request.ShortestUrl
            };
        }
    }
}
