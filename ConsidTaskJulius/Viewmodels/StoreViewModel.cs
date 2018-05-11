using ConsidTaskJulius.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ConsidTaskJulius.Helpers;
namespace ConsidTaskJulius.Viewmodels
{
    public class StoreViewModel
    {
        [Required]
        [RegularExpression(Regex.Guid, ErrorMessage = "Invalid GUID")]
        public System.Guid ID { get; set; }

        [Required]
        [RegularExpression(Regex.Guid, ErrorMessage = "Invalid GUID")]
        public System.Guid CompanyID { get; set; }

        [RegularExpression(Regex.StoreName, ErrorMessage = "Name can only contain letters and numbers!")]
        [Required(ErrorMessage = "A name is required")]
        public string Name { get; set; }

        [RegularExpression(Regex.Address, ErrorMessage = "Address can only contain letters and numbers!")]
        [Required(ErrorMessage = "An address is required")]
        public string Address { get; set; }

        [RegularExpression(Regex.City, ErrorMessage = "City can only contain letters!")]
        [Required(ErrorMessage = "A city is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "A zip is required")]
        [RegularExpression(Regex.Zip, ErrorMessage = "ZIP must be numeric and between 0 and 16 numbers long")]
        public string Zip { get; set; }

        [RegularExpression(Regex.Country, ErrorMessage = "Country can only contain letters!")]
        [Required(ErrorMessage = "A country is required!")]
        public string Country { get; set; }

        [RegularExpression(Regex.LatLong, ErrorMessage = "Longitude must be numeric")]
        public string Longitude { get; set; }

        [RegularExpression(Regex.LatLong, ErrorMessage = "Latitude must be numeric")]
        public string Latitude { get; set; }

        public List<Companies> companies { get; set; }
    }
}
