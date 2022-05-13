using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Domain.Common;

namespace UrlShortener.Domain.Model
{
    public class UrlShortenerEnity : EventLog
    {
        public long Id { get; set; }
        public string UrlShortenerGUID { get; private set; }
        public string MainUrl { get; private set; }
        public string ShortestUrl { get; private set; }

        public ICollection<UrlShortenerHistoryEnity> MyProperty { get; set; }

        protected UrlShortenerEnity() { }

        public UrlShortenerEnity(string urlShortenerGUID, string mainUrl, string shortestUrl)
        {
            UrlShortenerGUID = urlShortenerGUID;
            MainUrl = mainUrl;
            ShortestUrl = shortestUrl;
        }
    }
}
