using Application.NewsAPI.Models.Request;
using Application.NewsAPI.Services;
using Moq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.NewsApi.Testing
{
    public class NewsServiceTests
    {
        
        private NewsAPI.Services.NewsService _newsService;

        [SetUp]
        public void Setup()
        { 
            _newsService = new NewsAPI.Services.NewsService();
        }
        [Test]
        public async Task GetArticlesByCategory_ReturnsArticles_WhenResponseIsSuccessful()
        {
            // Arrange

            // Act
            var response = await _newsService.GetArticlesByCategory("business");


            // Assert
            Assert.AreEqual("ok", response.status);
            Assert.IsTrue(response.totalResults>= 5);
            Assert.IsNotNull(response.articles);
        }


    }
}
