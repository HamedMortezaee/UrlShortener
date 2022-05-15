using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UrlShortener.Application.Mappers;
using UrlShortener.Domain.Model;
using Microsoft.AspNetCore.WebUtilities;

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
            var code = 123_456_789;
            request.ShortestUrl = GetUrlChunk(code);
            var urlShortener = UrlShortenerMapper.Map(request);
            
            var id = await _urlShortenerRepository.Add(urlShortener);
            
            return new CreateUrlShortenerResult()
            {
                Id = id,
                MainUrl = request.MainUrl,
                ShortestUrl = request.ShortestUrl
            };
        }

        public string GetUrlChunk(long id)
        {
            // Transform the "Id" property on this object into a short piece of text
            return WebEncoders.Base64UrlEncode(BitConverter.GetBytes(id));
        }
    }
}
