using Application.Business_Logic.Contracts;
using Application.NewsAPI.Models.Request;
using Application.NewsAPI.Models.Response;
using Application.NewsService.Contracts;
using Application.NewsService.Models.Request;
using Application.NewsService.Models.Response;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.NewsAPI.Services
{
    public class NewsService : INewsService
    {
        private readonly NewsGatewayConfig _newsGatewayConfig;
        
        public NewsService()
        {
            
            var settingsFile = "newssettings.development.json";
            IConfiguration _config = new ConfigurationBuilder()
                       .AddJsonFile(settingsFile, optional: true, reloadOnChange: true).Build();

            _newsGatewayConfig = _config.GetSection("NewsAPIGatewayConfig").Get<NewsGatewayConfig>();
            
        }

        public async Task<(string status, long totalResults, List<ArticleDTO> articles)> GetArticlesByCategory(string category)
        {
            try
            {
                var client = new RestClient(_newsGatewayConfig.NewsUrl);
                var request = new RestRequest();

                category = category == "Miscellaneous" ? "general" : category;

                // Add query parameters
                request.AddParameter("category", category);
                request.AddParameter("apiKey", _newsGatewayConfig.NewsApiToken);


                // Execute the request and get the response
                var response = await client.ExecuteAsync(request);
                if (response.IsSuccessful)
                {
                    var newsByCategory = JsonConvert.DeserializeObject<NewsByCategory>(response.Content);
                    // Shuffle the list randomly
                    var random = new Random();

                    var articles = NewsByCategory.Parse(newsByCategory);

                    var shuffledArticles = articles.OrderBy(x => random.Next()).ToList();

                    // Take the first 5 elements from the shuffled list
                    var selectedArticles = shuffledArticles.Take(5).ToList();

                    Log.Information("Successfully retrieved  Articles By Category. Count: {count}", newsByCategory.totalResults);

                    return (newsByCategory.status, newsByCategory.totalResults, selectedArticles);

                }
                else
                {
                    Log.Error("Failed to retrieve  Bus regions. Status Code: {statusCode}, Error: {errorContent}", response.StatusCode, response.Content);
                    return ($"HTTP request error: {response.ErrorMessage}", 0, null);
                }
            }
            catch(Exception ex)
            {
                Log.Error("Error in retrieving data:{message}", ex.Message);
                return ($"HTTP request error", 0, null);

            }
        }
    }
}
