using ConsidTaskJulius.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConsidTaskJulius.Models
{
    public class BaseEntity
    {
        [Required]
        [RegularExpression(Regex.Guid, ErrorMessage = "Invalid GUID")]
        public Guid Id { get; set; }

    }
}
