using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Infostructure;
using BookStore.Models;
using BookStore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;

namespace BookStore.Controllers
{
    public class CartController : Controller
    {
        private IBookRepository repository;

        private Cart Cart;

        public CartController(IBookRepository repo, Cart cartservice)
        {
            repository = repo;

            Cart = cartservice;

        }



        public RedirectToActionResult AddToCart(int bookid, string returnURl)
        {
            Book book = repository.Books.Where(book => book.BookId == bookid).FirstOrDefault();

            if (book != null)
            {
                Cart cart = GetCart();

                cart.AddOrder(book, 1);

                SaveCart(cart);
            }
           

            return RedirectToAction("Index", new { returnURl });
        }


        public RedirectToActionResult RemoveFromCart(int bookid, string returnUrl)
        {
            Book book = repository.Books.FirstOrDefault(book => book.BookId == bookid);

            if (book != null)
            {
                Cart cart = GetCart();

                cart.RemoveOrder(book);

                SaveCart(cart);
            }

            return RedirectToAction("Index", new { returnUrl });

        }


        public IActionResult Index(string returnUrl)
        {
            return View("Cart", new CartIndexViewModel { 
                Cart = GetCart(),
                ReturnUrl=returnUrl
                
            });

        }

        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJson("Cart", cart);
        }

        private Cart GetCart()
        {
            Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();

            return cart;
        }



    }
}
