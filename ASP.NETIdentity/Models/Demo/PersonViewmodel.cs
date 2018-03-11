using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NETIdentity.Models.Demo
{
    public class PersonViewmodel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CountryId { get; set; }
        public List<Country> Countrys { get; set; }

        public int CityId { get; set; }

       // public City City { get; set; }
    }
}