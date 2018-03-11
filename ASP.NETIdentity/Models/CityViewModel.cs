using ASP.NETIdentity.Models.Demo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP.NETIdentity.Models
{
    public class CityViewModel
    {
        [Required]
        public string Name { get; set; }

        public int CountryName { get; set; }

        //public string CountryName { get; set; }

        public Country Country { get; set; }

       // public City City { get; set; }


    }
}