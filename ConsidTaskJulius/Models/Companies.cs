using ConsidTaskJulius.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsidTaskJulius.Models
{
    public partial class Companies
    {
        public Companies()
        {
            Stores = new HashSet<Stores>();
        }

        [Required]
        [RegularExpression(Regex.Guid, ErrorMessage = "Invalid GUID")]
        public Guid Id { get; set; }

        [Required]
        [RegularExpression(Regex.CompanyName, ErrorMessage ="Company can only contain numbers and letters!")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(Regex.OrganizationNumber, ErrorMessage = "Organization number can only contain numbers!")]
        public int OrganizationNumber { get; set; }


        [RegularExpression(Regex.Notes, ErrorMessage = "Notes can not contain special characters!")]
        public string Notes { get; set; }


        public ICollection<Stores> Stores { get; set; }
    }
}
