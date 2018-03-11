using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASP.NETIdentity.Models.Demo
{
    public class City
    {
        [Key]
        public int CityId { get; set; }

        public string CityName { get; set; }

        [ForeignKey(name: "Country")]
        public int CountryId { get; set; }
        public Country Country { get; set; }

        public List<Person> People { get; set; }
    }
}