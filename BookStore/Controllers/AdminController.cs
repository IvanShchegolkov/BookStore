using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class AdminController : Controller
    {
        public IBookRepository _repository { get; set; }

        public AdminController(IBookRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index() => View(_repository.Books);

        public IActionResult Edit(int BookId) =>  View(_repository.Books
            .FirstOrDefault(Book => Book.BookId == BookId));


        [HttpPost]
        public IActionResult Edit(Book book)
        {

            if (ModelState.IsValid)
            {
                _repository.SaveBook(book);
                TempData["message"] = $" {book.Name} have been saved";
                return RedirectToAction("Index");
            }
            else
            {
                return View(book);
            }
        }

        public IActionResult Create() => View("Edit", new Book());

        [HttpPost]
        public IActionResult Delete(int bookid)
        {
            Book deleteBook = _repository.Books
                .FirstOrDefault(b => b.BookId == bookid);

            if(deleteBook!=null)
            {
               var result = _repository.DeleteBook(deleteBook);

                if(result==null)
                {
                    TempData["message"] = $"{deleteBook.Name} was deleted!";
                }   

            }

            return RedirectToAction("Index");

        }







    }
}
