using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace BooStore.Tests
{
    public class CartTests
    {

        [Fact]
        public void Can_Add_New_Orders()
        {
            Book book1 = new Book { BookId = 1, Name = "B1" };
            Book book2 = new Book { BookId = 2, Name = "B2" };

            Cart cart = new Cart();

            cart.AddOrder(book1, 1);
            cart.AddOrder(book2, 1);

            Order[] orders = cart.Orders.ToArray();

            Assert.Equal(book1.Name, orders[0].Book.Name);
            Assert.Equal(book2.Name, orders[1].Book.Name);
            Assert.Equal(2, orders.Length);
        }


        
        [Fact]
        public void Can_Add_Quanity_For_Existing_Order()
        {
            Book book1 = new Book { BookId = 1, Name = "B1" };
            Book book2 = new Book { BookId = 2, Name = "B2" };

            Cart cart = new Cart();

            cart.AddOrder(book1, 1);
            cart.AddOrder(book1, 3);
            cart.AddOrder(book2, 10);

            Order[] orders = cart.Orders.OrderBy(c => c.Book.BookId).ToArray();

            Assert.Equal(4, orders[0].Quanity);
            Assert.Equal(10, orders[1].Quanity);
            Assert.Equal(2, orders.Length);

        }

        [Fact]
        public void Can_Delete_Order_From_Cart()
        {
            Book book1 = new Book { BookId = 1, Name = "B1" };
            Book book2 = new Book { BookId = 2, Name = "B2" };
            Book book3 = new Book { BookId = 3, Name = "B3" };

            Cart cart = new Cart();

            cart.AddOrder(book1, 2);
            cart.AddOrder(book2, 1);
            cart.AddOrder(book3, 4);

            cart.RemoveOrder(book3);

            Assert.Equal(2, cart.Orders.Count());

        }


        [Fact]
        public void Total_Cart_SUm()
        {
            Book book1 = new Book { BookId = 1, Name = "B1", Price = 100m };
            Book book2 = new Book { BookId = 2, Name = "B2", Price = 200m };

            Cart cart = new Cart();

            cart.AddOrder(book1, 2);
            cart.AddOrder(book2, 2);

            decimal totalsum = cart.ComputeTotalPrice();

            Assert.Equal(600m, totalsum);


        }

        [Fact]
        public void Can_Clear_Cart()
        {
            Book book1 = new Book { BookId = 1, Name = "B1", Price = 100m };
            Book book2 = new Book { BookId = 2, Name = "B2", Price = 200m };

            Cart cart = new Cart();

            cart.AddOrder(book1, 2);
            cart.AddOrder(book2, 2);

            cart.Clear();

            Assert.Empty(cart.Orders);


        }
    }
}
