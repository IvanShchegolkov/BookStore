using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Conrollers
{
    public class BookController : Controller
    {

        private IBookRepository repository;

        public int PageSize = 4;

        public BookController(IBookRepository repo)
        {
            repository = repo;
        }

        public ViewResult List (int ProductPage = 1)
        {
           return View(new BooksListViewModel
            {
                Books = repository.Books
                .OrderBy(books => books.BookId)
                .Skip((ProductPage - 1) * PageSize)
                .Take(PageSize),
                PageInfo = new PageInfo
                {
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Books.Count()
                },

            });;
        }

       
    }
}
