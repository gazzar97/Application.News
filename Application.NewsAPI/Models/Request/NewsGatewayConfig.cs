using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.NewsAPI.Models.Request
{
    public class NewsGatewayConfig
    {
        public string NewsUrl { get; set; }
        public string NewsApiToken { get; set; }
    }
}
