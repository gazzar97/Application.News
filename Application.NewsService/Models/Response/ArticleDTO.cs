using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.NewsService.Models.Response
{
    public class ArticleDTO
    {
        public string SourceName { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public DateTime publishedAt { get; set; }
       
    }
}
