using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class SearchController : Controller
    {
        private IBookRepository repository;

      

        public SearchController(IBookRepository bookRepository)
        {
            repository = bookRepository;
        }

        
        public IActionResult Index(string query)
        {
            if (query == null)
                return View("Empty");

            var books = repository.BooksByAuthorOrName(query);

            if (books==null)
            {
                return View("Emty");
            }
            return View(books);


        }
    }
}
