using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public interface IBookRepository 
    {
        IQueryable<Book> Books { get; }

        IEnumerable<Book> BooksByAuthorOrName(string query);

        void SaveBook(Book book);

        Book DeleteBook(Book book);

    }
}
