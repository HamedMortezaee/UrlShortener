using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Domain.Common;

namespace UrlShortener.Domain.Model
{
    public class UrlShortenerHistoryEnity : EventLog
    {
        public long Id { get; set; }
        public long UrlShortenerId { get; private set; }

        public UrlShortenerEnity UrlShortener { get; set; }

        protected UrlShortenerHistoryEnity() { }

        public UrlShortenerHistoryEnity(long urlShortenerId)
        {
            UrlShortenerId = urlShortenerId;
        }

    }
}
