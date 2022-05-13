using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Domain.Common;

namespace UrlShortener.Domain.Model
{
    public class UrlShortener : EventLog
    {
        public long Id { get; set; }
        public string MainUrl { get; private set; }
        public string ShortestUrl { get; private set; }

        public ICollection<UrlShortenerHistory> MyProperty { get; set; }

        protected UrlShortener() { }

        public UrlShortener(string mainUrl, string shortestUrl)
        {
            MainUrl = mainUrl;
            ShortestUrl = shortestUrl;
        }
    }
}
