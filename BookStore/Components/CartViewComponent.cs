using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Components
{
    public class CartViewComponent : ViewComponent
    {
        private Cart cart;

        public CartViewComponent(Cart CartService)
        {
            cart = CartService;
        }

        public IViewComponentResult Invoke()
        {
            return View(cart);
        }

    }
}
