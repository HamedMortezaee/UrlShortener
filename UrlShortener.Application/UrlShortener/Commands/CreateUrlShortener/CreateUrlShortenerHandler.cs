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
    public class CreateUrlShortenerHandler : IRequestHandler<CreateUrlShortenerRequest, CreateUrlShortenerResult>
    {
        private readonly IUrlShortenerRepository _urlShortenerRepository;

        public CreateUrlShortenerHandler(IUrlShortenerRepository urlShortenerRepository)
        {
            _urlShortenerRepository = urlShortenerRepository;
        }

        public async Task<CreateUrlShortenerResult> Handle(CreateUrlShortenerRequest request, CancellationToken cancellationToken)
        {
            var isexistMainUrl = _urlShortenerRepository.GetByMainUrl(request.MainUrl).Result;
            if (isexistMainUrl != null)
                throw new Exception("این دامین تکراری می باشد");

            var code = await this.GetCode();
            var base_url = "https://gly.com";
            request.ShortestUrl = $"{base_url}/{code}";

            var urlShortener = UrlShortenerMapper.Map(request);
            
            var id = await _urlShortenerRepository.Add(urlShortener);
            
            return new CreateUrlShortenerResult()
            {
                Id = id,
                MainUrl = request.MainUrl,
                ShortestUrl = request.ShortestUrl
            };
        }

        private async Task<string> GetCode()
        {
            var urlShorteners = await _urlShortenerRepository.GetAll();
            var isExist = false;
            var code = string.Empty;
            do
            {
                code = Guid.NewGuid().ToString().Substring(0, 7);
                var urlShortener = _urlShortenerRepository.GetByurlShortenerGUID(code);
                isExist = urlShorteners.Any(x => x.ShortestUrl.Contains(code));
            } while (isExist);
            return code;            
        }

    }
}
