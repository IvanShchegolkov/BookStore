using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class EFBookRepository : IBookRepository
    {
        private ApplicationDbContext context;

        public EFBookRepository(ApplicationDbContext ef)
        {
            context = ef;
        }

        public IQueryable<Book> Books => context.Books;

        public IEnumerable<Book> BooksByAuthorOrName(string query)
        {
            return context.Books.Where(book => book.Author.Contains(query) ||
            book.Name.Contains(query));
        }

        public Book DeleteBook(Book book)
        {
            Book dbDelete = context.Books.FirstOrDefault(b => b.BookId == book.BookId);

            if (dbDelete!=null)
            {
                context.Remove(dbDelete);
                context.SaveChanges();
            }

            context.SaveChanges();

            return dbDelete;

        }

        public void SaveBook(Book book)
        {
            if (book.BookId == 0)
            {
                context.Books.Add(book);
                context.SaveChanges();
            }
            else
            {
                Book dbsave = context.Books
                    .FirstOrDefault(b => b.BookId == book.BookId);

                if (dbsave != null)
                {
                    dbsave.Author = book.Author;
                    dbsave.Description = book.Description;
                    dbsave.Name = book.Name;
                    dbsave.Price = book.Price;
                }

                context.SaveChanges();
            }
        }


    }
}
