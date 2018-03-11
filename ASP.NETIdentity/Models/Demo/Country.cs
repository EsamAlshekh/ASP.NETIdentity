using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP.NETIdentity.Models.Demo
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        [Required]
        public string ContryName { get; set; }

        public List<City> cities { get; set; }


        //public List<Person> People { get; set; }
    }
}