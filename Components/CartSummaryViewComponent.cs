using Microsoft.AspNetCore.Mvc;
using AmazonStartUp.Models;
using AmazonStartUp.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace AmazonStartUp.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart _Cart;

        public CartSummaryViewComponent(Cart cartService)
        {
            _Cart = cartService;
        }

        public IViewComponentResult Invoke()
        {
            return View(_Cart);
        }
    }
}
