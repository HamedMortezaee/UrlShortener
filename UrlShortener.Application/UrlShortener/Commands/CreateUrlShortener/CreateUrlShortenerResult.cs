using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Application.Content.UrlShortener.Commands.CreateUrlShortener
{
    public class CreateUrlShortenerResult
    {
        public long Id { get; set; }
        public string MainUrl { get; set; }
        public string ShortestUrl { get; set; }
    }
}
