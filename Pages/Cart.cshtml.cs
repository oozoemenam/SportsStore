using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportsStore.Infrastructure;
using SportsStore.Models;
using SportsStore.Repositories;

namespace SportsStore.Pages
{
    public class CartModel : PageModel
    {
        private IStoreRepository repository;

        public CartModel(IStoreRepository repository, Cart cartService)
        {
            this.repository = repository;
            this.Cart = cartService;
        }

        public Cart Cart { get; set; }

        public string ReturnUrl { get; set; } = "/";

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            // Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(long id, string returnUrl)
        {
            Product? product = repository.Products
                .FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                Cart.AddItem(product, 1);
            }
            return RedirectToPage(new { returnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(long id, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl => cl.Product.Id == id).Product);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
