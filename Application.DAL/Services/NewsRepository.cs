using Application.Business_Logic.Contracts;
using Application.NewsService.Contracts;
using Application.NewsService.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DAL.Services
{
    public class NewsRepository : INewsRepository
    {
        private readonly INewsService _newsService;

        public NewsRepository(INewsService newsService)
        {
            _newsService = newsService;
        }
        public async Task<(string status, List<ArticleDTO> articles)> GetArticlesByCategory(string category)
        {
            var results = await _newsService.GetArticlesByCategory(category);
            return (results.status, results.articles);
        }
    }
}
