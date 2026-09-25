using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Domain.Common
{
    public class EventLog
    {
        public DateTime RegisterDate { get; set; }
        public string RegisterUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateUserId { get; set; }
        public DateTime? DeleteDate { get; set; }
        public string DeleteUserId { get; set; }
        public bool IsDelete { get; set; }
    }
}
