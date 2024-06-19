using Application.Business_Logic.Contracts;
using Application.NewsService.Contracts;
using Application.NewsService.Models.Response;
using Serilog;
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
            try
            {
                var results = await _newsService.GetArticlesByCategory(category);
                return (results.status, results.articles);
            }
            catch (Exception ex)
            {
                // Log the exception as needed, for example:
                Log.Error(ex, "An error occurred while fetching articles.");
                return ("error", new List<ArticleDTO>());
            }
        }

    }
}
