using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonStartUp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AmazonStartUp.Infrastructure;

namespace AmazonStartUp.Pages
{
    public class CartModel : PageModel
    {
        private IAmazonRepo _repo;

        public CartModel(IAmazonRepo repo)
        {
            _repo = repo;
        }

        public Cart Cart { get; set; }

        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            string ReturnUrl = returnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnGetBack(string returnUrl)
        {
            return RedirectToPage(new { returnUrl = returnUrl });
        }

        public IActionResult OnPost(long bookId, string returnUrl)
        {
            Book book = _repo.Books.FirstOrDefault(b => b.BookId == bookId);

            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            Cart.AddItem(book, 1);

            HttpContext.Session.SetJson("cart", Cart);

            return RedirectToPage(new { returnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(long bookId, string returnUrl)
        {
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            Cart.RemoveLine(Cart.Lines.First(tr =>
                tr.Book.BookId == bookId).Book);

            HttpContext.Session.SetJson("cart", Cart);

            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
