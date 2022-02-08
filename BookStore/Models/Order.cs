using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public Book Book { get; set; }

        public int Quanity { get; set; }


    }
}
