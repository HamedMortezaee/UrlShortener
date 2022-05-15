using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Application.Content.UrlShortenerHistory.Commands.CreateUrlShortenerAccessHistory
{
    public class CreateUrlShortenerRequestHistory : IRequest<CreateUrlShortenerHistoryResult>
    {
        public long UrlShortenerId { get; set; }
    }
}
