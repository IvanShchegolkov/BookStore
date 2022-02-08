using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class FakeBookRepository /*: IBookRepository*/
    {
        public IQueryable<Book> Books => new List<Book>
        {
            new Book {Name = "Алгоритмы, построение и анализ", Author = "Алан Пивз", Price = 25},
            new Book {Name = "Гарри Поттер", Author = "Джоан Роулинг", Price = 12},
            new Book {Name = "Качая железо", Author = "Арнольд Шварцнегер", Price=11}
        }.AsQueryable<Book>();

        public IEnumerable<Book> BooksByAuthorOrName(string query)
        {
            return Books.Where(book => book.Name.Contains(query) || book.Author.Contains(query)).ToArray();
        }
    }
}
