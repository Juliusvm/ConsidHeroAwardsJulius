using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsidTaskJulius.Helpers
{
    public class Regex
    {
        public const string Zip = "^[0-9]{0,16}$";
        public const string Country = "^[a-zA-ZäöåÄÖÅ]{0,50}$";
        public const string Address = "^[a-zA-ZäöåÄÖÅ, , 0-9]{0,512}$";
        public const string StoreName = "^[a-zA-ZäöåÄÖÅ, , 0-9]{0,100}$";
        public const string City = "^[a-zA-ZäöåÄÖÅ]{0,512}$";
        public const string LatLong = "^[0-9]*[.]*[0-9]*";
        public const string CompanyName = "^[a-zA-ZäöåÄÖÅ, , 0-9]{0,255}$";
        public const string OrganizationNumber = "^[0-9]*$";
        public const string Notes = "^[a-zA-ZäöåÄÖÅ, 0-9, ,]*$";
        public const string Guid = "^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$";
    }
}
