using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Application.Content.UrlShortener.Queries
{
    public class UrlShortenerItemQuery : IRequest<UrlShortenerItemResultQuery>
    {
        public string UrlShortenerGUID { get; set; }
    }
}
