using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP.NETIdentity.Models
{
    public class PersonViewModel
    {
        
        [Required]
        public string Name { get; set; }

        public int CountryId { get; set; }

        public int CityId { get; set; }
    }
}