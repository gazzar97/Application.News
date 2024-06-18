using Application.Business_Logic.Contracts;
using Application.Client.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Linq;
using System.Diagnostics;
using Application.Domain.Entities;

namespace Application.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPageRepository _pageRepository;
        private readonly INewsRepository _newsRepository;
        public HomeController(ILogger<HomeController> logger, IPageRepository pageRepository,
            INewsRepository newsRepository)
        {
            _logger = logger;
            _pageRepository = pageRepository;
            _newsRepository = newsRepository;
           
        }
        // Technology
        public async Task<IActionResult> Technology()
        {
            try
            {
                var pages = await _pageRepository.GetAll();
                var pageTitle = pages.FirstOrDefault(p => p.PageTitle == "Technology")?.PageTitle;

                if (pageTitle != null)
                {
                    ViewBag.Title = pageTitle;
                    var Articles = await _newsRepository.GetArticlesByCategory(pageTitle);
                    ViewBag.Articles = Articles;
                    return View();
                }
                else
                {
                    // Handle case where "Technology" page is not found
                    ViewBag["Title"] = "Page Not Found";
                    return View("NotFound"); // Assuming you have a NotFound.cshtml view
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Log.Error(ex, "Error in Technology action method");

                // Optionally handle or display a generic error view
                return View("Error"); // Assuming you have an Error.cshtml view
            }
        }

        // Business
        public async Task<IActionResult> Business()
        {
            try
            {
                var pages = await _pageRepository.GetAll();
                var pageTitle = pages.FirstOrDefault(p => p.PageTitle == "Business")?.PageTitle;

                if (pageTitle != null)
                {
                    ViewBag.Title = pageTitle;
                    var Articles = await _newsRepository.GetArticlesByCategory(pageTitle);
                    ViewBag.Articles = Articles;
                    return View();
                }
                else
                {
                    // Handle case where "Technology" page is not found
                    ViewBag["Title"] = "Page Not Found";
                    return View("NotFound"); // Assuming you have a NotFound.cshtml view
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Log.Error(ex, "Error in Business action method");

                // Optionally handle or display a generic error view
                return View("Error"); // Assuming you have an Error.cshtml view
            }
        }
        // Entertainment
        public async Task<IActionResult> Entertainment()
        {
            try
            {
                var pages = await _pageRepository.GetAll();
                var pageTitle = pages.FirstOrDefault(p => p.PageTitle == "Entertainment")?.PageTitle;

                if (pageTitle != null)
                {
                    ViewBag.Title = pageTitle;
                    var Articles = await _newsRepository.GetArticlesByCategory(pageTitle);
                    ViewBag.Articles = Articles;
                    return View();
                }
                else
                {
                    // Handle case where "Technology" page is not found
                    ViewBag["Title"] = "Page Not Found";
                    return View("NotFound"); // Assuming you have a NotFound.cshtml view
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Log.Error(ex, "Error in Business action method");

                // Optionally handle or display a generic error view
                return View("Error"); // Assuming you have an Error.cshtml view
            }
        }
        //  Miscellaneous
        public async Task<IActionResult> Miscellaneous()
        {
            try
            {
                var pages = await _pageRepository.GetAll();
                var pageTitle = pages.FirstOrDefault(p => p.PageTitle == "Miscellaneous")?.PageTitle;

                if (pageTitle != null)
                {
                    ViewBag.Title = pageTitle;
                    var Articles = await _newsRepository.GetArticlesByCategory(pageTitle);
                    ViewBag.Articles = Articles;
                    return View();
                }
                else
                {
                    // Handle case where "Technology" page is not found
                    ViewBag["Title"] = "Page Not Found";
                    return View("NotFound"); // Assuming you have a NotFound.cshtml view
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Log.Error(ex, "Error in Business action method");

                // Optionally handle or display a generic error view
                return View("Error"); // Assuming you have an Error.cshtml view
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
