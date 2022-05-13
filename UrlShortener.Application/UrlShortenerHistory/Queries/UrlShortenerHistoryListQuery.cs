using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Application.UrlShortenerHistory.Queries
{
    public class UrlShortenerHistoryListQuery : IRequest<UrlShortenerHistoryListResultQuery>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ShortUrl { get; set; }
    }
}
