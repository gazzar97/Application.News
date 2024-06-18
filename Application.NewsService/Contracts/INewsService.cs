using Application.NewsService.Models.Request;
using Application.NewsService.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.NewsService.Contracts
{
    public interface INewsService
    {
        Task<(string status, long totalResults, List<ArticleDTO> articles)> GetArticlesByCategory(string category);
    }
}
