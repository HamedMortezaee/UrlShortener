using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Application.Content.UrlShortenerHistory.Commands.CreateUrlShortenerAccessHistory
{
    public class CreateUrlShortenerHistoryResult
    {
        public long Id { get; set; }
        public long UrlShortenerId { get; set; }
    }
}
