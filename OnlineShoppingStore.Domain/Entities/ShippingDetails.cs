using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingStore.Domain.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter street name")]
        public string Street { get; set; }
        [Required(ErrorMessage = "Please enter city name")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter postcode")]
        public string PostCode { get; set; }

        public bool GiftWrap { get; set; }
        
    }
}
