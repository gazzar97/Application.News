using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.NewsService.Models.Request
{
    public class NewsFilter
    {
        public string Category { get; set; }
        public DateOnly From { get; set; }
        public DateOnly To { get; set; }
    }
}
