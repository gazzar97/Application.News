using Application.NewsService.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Business_Logic.Contracts
{
    public interface INewsRepository
    {
        Task<(string status, List<ArticleDTO> articles)> GetArticlesByCategory(string category);
    }
}
