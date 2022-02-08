using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [Required(ErrorMessage = "Pls Enter a Book name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Pls Enter a Description")]
        public string Description { get; set; }



        [Required]
        [Range(50, double.MaxValue, ErrorMessage = "Pls Enter An Positive Price")]
        public decimal Price { get; set; }


        public string Category { get; set; }


        [Required(ErrorMessage = "pls enter an author")]
        public string Author { get; set; }


    }
}
