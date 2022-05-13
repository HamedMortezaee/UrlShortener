using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Application.Content.UrlShortener.Commands.CreateUrlShortener
{
    public class CreateUrlShortener : IRequest<CreateUrlShortenerResult>
    {
        public string MainUrl { get; set; }
        public string ShortestUrl { get; set; }
    }
}
