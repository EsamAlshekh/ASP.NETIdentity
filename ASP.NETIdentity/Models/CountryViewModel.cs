using ASP.NETIdentity.Models.Demo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP.NETIdentity.Models
{
    public class CountryViewModel
    {
        [Required]
        public string CountryName { get; set; }

        public List<City> cities { get; set; }
    }
}