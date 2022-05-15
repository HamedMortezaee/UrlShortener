using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Application.Content.UrlShortener.Queries
{
    public class UrlShortenerItemRequestQuery : IRequest<UrlShortenerItemResultQuery>
    {
        public string UrlShortenerGUID { get; set; }
    }
}
