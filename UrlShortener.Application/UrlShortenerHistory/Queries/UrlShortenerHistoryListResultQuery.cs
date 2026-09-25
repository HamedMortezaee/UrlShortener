using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Application.UrlShortenerHistory.Queries
{
    public class UrlShortenerHistoryListResultQuery
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CallShortUrlCount { get; set; }
    }
}
