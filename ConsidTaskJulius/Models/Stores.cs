using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsidTaskJulius.Models
{
    public partial class Stores : BaseEntity
    {

        [Required]
        public Guid CompanyId { get; set; }

        [Required]
        public string Name { get; set; }

     
        [Required]
        public string Address { get; set; }

        [RegularExpression("/[^a-zA-Z]/")]
        [Required]
        public string City { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "ZIP must be numeric")]
        public string Zip { get; set; }

        [Required]
        public string Country { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }

        public Companies Company { get; set; }
    }
}
