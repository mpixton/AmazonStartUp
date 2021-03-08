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

        public Cart Cart { get; set; }

        public string ReturnUrl { get; set; }

        public CartModel(IAmazonRepo repo, Cart cartService)
        {
            _repo = repo;
            Cart = cartService;
        }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnGetBack(string returnUrl)
        {
            return RedirectToPage(new { returnUrl = returnUrl });
        }

        public IActionResult OnPost(long bookId, string returnUrl)
        {
            Book book = _repo.Books.FirstOrDefault(b => b.BookId == bookId);

            Cart.AddItem(book, 1);

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
