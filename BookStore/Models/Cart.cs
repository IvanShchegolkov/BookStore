using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Cart
    {


        private List<Order> OrderCollection = new List<Order>();

        public virtual void AddOrder(Book book, int quanity)
        {
            Order order = OrderCollection.Where(order => order.Book.BookId == book.BookId).FirstOrDefault();

            if (order == null)
            {
                OrderCollection.Add(new Order
                {
                    Book = book,
                    Quanity = quanity

                });

            }
            else order.Quanity += quanity;
                

        }

        public virtual void RemoveOrder(Book book) => OrderCollection.RemoveAll(order => order.Book.BookId == book.BookId);

        public virtual decimal ComputeTotalPrice() => OrderCollection.Sum(order => order.Book.Price * order.Quanity);

        public virtual void Clear() => OrderCollection.Clear();

        public virtual IEnumerable<Order> Orders => OrderCollection;







    }

}
