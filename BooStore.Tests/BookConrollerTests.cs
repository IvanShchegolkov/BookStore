    using BookStore.Conrollers;
using BookStore.Models;
using Moq;
using System;
using System.Linq;
using Xunit;
using System.Collections.Generic;
using BookStore.Models.ViewModels;

namespace BooStore.Tests
{
    public class BookConrollerTests
    {
        [Fact]
        public void Can_Paginate()
        {
            Mock<IBookRepository> mock = new Mock<IBookRepository>();

            mock.Setup(m => m.Books).Returns((new Book[]
            { new Book{BookId=1, Name="B1"},
            new Book{BookId=2, Name="B2"},
            new Book{BookId=3, Name="B3"},
            new Book{BookId=4, Name="B4"},
            new Book{BookId=5, Name="B5"},
            new Book{BookId=6, Name="B6"}
            }).AsQueryable<Book>());

            BookController controller = new BookController(mock.Object);
            
            controller.PageSize = 3;



            BooksListViewModel result = controller.List(2).ViewData.Model as BooksListViewModel;

            Book[] booksArray = result.Books.ToArray();

            Assert.True(booksArray.Length == 3);
            Assert.Equal("B4", booksArray[0].Name);
            Assert.Equal("B5", booksArray[1].Name);
            Assert.Equal("B6", booksArray[2].Name);
        }

        [Fact]
        public void Can_Send_Pagination_View_Model()
        {
            Mock<IBookRepository> mock = new Mock<IBookRepository>();
            mock.Setup(m => m.Books).Returns((new Book[]
           { new Book{BookId=1, Name="B1"},
            new Book{BookId=2, Name="B2"},
            new Book{BookId=3, Name="B3"},
            new Book{BookId=4, Name="B4"},
            new Book{BookId=5, Name="B5"}
           }).AsQueryable<Book>());


            BookController controller = new BookController(mock.Object) { PageSize = 3 };

            BooksListViewModel result = controller.List(2).ViewData.Model as BooksListViewModel;

            PageInfo page = result.PageInfo;

            Assert.Equal(3, page.ItemsPerPage);
            Assert.Equal(5, page.TotalItems);
            Assert.Equal(2, page.TotalPages);






        }

    }
}
