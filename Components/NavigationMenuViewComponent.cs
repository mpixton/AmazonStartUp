using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonStartUp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AmazonStartUp.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IAmazonRepo _repo;

        public NavigationMenuViewComponent(IAmazonRepo amazonRepo)
        {
            _repo = amazonRepo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            return View(
                _repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x)
            );
        }
    }
}
