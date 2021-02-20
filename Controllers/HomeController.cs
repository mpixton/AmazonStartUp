using AmazonStartUp.Models;
using AmazonStartUp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonStartUp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IAmazonRepo _amazonRepo;

        public int PageSize = 5;

        public HomeController(ILogger<HomeController> logger, IAmazonRepo repo)
        {
            _logger = logger;
            _amazonRepo = repo;
        }

        public IActionResult Index(int page = 1)
        {
            return View(
                new BookViewModel
                {
                    Books = _amazonRepo.Books
                            .OrderBy(b => b.BookId)
                            .Skip((page - 1) * PageSize)
                            .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _amazonRepo.Books.Count()
                    }
                }
            );
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
