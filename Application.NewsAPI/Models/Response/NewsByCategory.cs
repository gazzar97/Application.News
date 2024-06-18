using Application.NewsService.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.NewsAPI.Models.Response
{
    public class NewsByCategory
    {
        public string status { get; set; }
        public int totalResults { get; set; }
        public List<Article> articles { get; set; }

        public static List<ArticleDTO> Parse(NewsByCategory news)
        {
            // Check if the news object or its Articles property is null
            if (news == null || news.articles == null)
            {
                return new List<ArticleDTO>();
            }

            // Map each Article to ArticleDTO
            var articleDTOs = news.articles.Select(article => new ArticleDTO
            {
                SourceName = article.source?.name,  // Safely access the source name
                Author = article.author,
                Title = article.title,
                Description = article.description,
                Url = article.url,
                publishedAt = article.publishedAt
            }).ToList();

            return articleDTOs;

        }
    }
}
