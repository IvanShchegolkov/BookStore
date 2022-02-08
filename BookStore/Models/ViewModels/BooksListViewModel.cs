using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.ViewModels
{
    public class BooksListViewModel
    {
        public IEnumerable<Book> Books { get; set; } 

        public PageInfo PageInfo { get; set; }

        public string CurrentCategory { get; set; }
    }
}
