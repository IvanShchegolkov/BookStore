using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class OrderController : Controller
    {
        private IUsersOrderInformationRepository _repository;

        private Cart cart;

        public OrderController(IUsersOrderInformationRepository repository, Cart cartservice)
        {
            _repository = repository;

            cart = cartservice;
        }

        public IActionResult List() => View(_repository.Orders.Where(o => !o.Shiipped));

        [HttpPost]
        public IActionResult MarkShipped(int orderId)
        {
            UsersOrderInformation order = _repository.Orders.FirstOrDefault(order => order.UsersOrderInformationId==orderId);
            if(order!=null)
            {
                order.Shiipped = true;
                _repository.SaveOrder(order);
            }
            return RedirectToAction(nameof(List));


        }


        public IActionResult Checkout() => View(new UsersOrderInformation());

        [HttpPost]
        public IActionResult Checkout(UsersOrderInformation order)
        {
            if(cart.Orders.Count()==0)
            {
                ModelState.AddModelError("", "sorry! your cart is empty!");

            }

            if (ModelState.IsValid)
            {
                order.Orders = cart.Orders.ToArray();

                _repository.SaveOrder(order);

                return RedirectToAction(nameof(Completed));
            }
            else
                return View(order);

        }

        public ViewResult Completed()
        {
            cart.Clear();
            return View();
        }
    }
}
