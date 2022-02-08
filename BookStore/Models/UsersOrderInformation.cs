using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class UsersOrderInformation
    {
        [BindNever]
        public int UsersOrderInformationId { get; set; }
        [BindNever]
        public ICollection<Order> Orders { get; set; }

        [BindNever]
        public bool Shiipped { get; set; }

        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter the First adress Line")]
     
        public string Street { get; set; }
        [Required(ErrorMessage = "Please Enter a city name")]
        public string City { get; set; }

        [Required(ErrorMessage ="Please Enter your PostCode")]
        public int PostCode { get; set; }

        public bool GiftWrap { get; set; }




    }
}
