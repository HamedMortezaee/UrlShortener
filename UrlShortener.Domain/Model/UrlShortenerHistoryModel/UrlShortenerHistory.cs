using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Domain.Common;

namespace UrlShortener.Domain.Model
{
    public class UrlShortenerHistory : EventLog
    {
        public long Id { get; set; }
        public long UrlShortenerId { get; private set; }

        public UrlShortener UrlShortener { get; set; }

        protected UrlShortenerHistory() { }

        public UrlShortenerHistory(long urlShortenerId)
        {
            UrlShortenerId = urlShortenerId;
        }

    }
}
