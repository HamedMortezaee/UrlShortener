using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Application.Content.UrlShortener.Queries
{
    public class UrlShortenerItemResultQuery
    {
        public long Id { get; set; }
        public string MainUrl { get; set; }
        public string ShortestUrl { get; set; }
    }
}
