﻿using Application.NewsAPI.Models.Request;
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
            var isDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";

            var settingsFile = isDevelopment ? "newssettings.development.json" : "newssettings.json";
            IConfiguration _config = new ConfigurationBuilder()
                       .AddJsonFile(settingsFile, optional: true, reloadOnChange: true).Build();

            _newsGatewayConfig = _config.GetSection("NewsAPIGatewayConfig").Get<NewsGatewayConfig>();

        }

        public async Task<(string status, long totalResults, List<ArticleDTO> articles)> GetArticlesByCategory()
        {
            var client = new RestClient(_newsGatewayConfig.NewsUrl);
            var request = new RestRequest("top-headlines", Method.Get);
            request.AddHeader("content-type", "application/json");

            // Add query parameters
            request.AddParameter("country", "us");
            request.AddParameter("category", "business");
            request.AddParameter("apiKey", _newsGatewayConfig.NewsApiToken);


            // Execute the request and get the response
            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                var newsByCategory = JsonConvert.DeserializeObject<NewsByCategory>(response.Content);
                var articles =  NewsByCategory.Parse(newsByCategory);
                Log.Information("Successfully retrieved  Articles By Category. Count: {count}", newsByCategory.totalResults);

                return (newsByCategory.status, newsByCategory.totalResults, articles);

            }
            else
            {
                Log.Error("Failed to retrieve  Bus regions. Status Code: {statusCode}, Error: {errorContent}", response.StatusCode, response.Content);
                return ($"HTTP request error: {response.ErrorMessage}", 0, null);
            }
        }
    }
}
