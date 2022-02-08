using BookStore.Infostructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class SessionCart : Cart
    {
        [JsonIgnore]
        public ISession Session { get; set; }


        public static Cart GetCart (IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            SessionCart cart = session?.GetJson<SessionCart>("Cart") ?? new SessionCart();

            cart.Session = session;

            return cart;
        }


        public override void AddOrder(Book book, int quanity)
        {
            base.AddOrder(book, quanity);
            Session.SetJson("Cart", this);

        }

        public override void RemoveOrder(Book book)
        {
            base.RemoveOrder(book);
            Session.SetJson("Cart", this);

        }

        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }



    }
}
