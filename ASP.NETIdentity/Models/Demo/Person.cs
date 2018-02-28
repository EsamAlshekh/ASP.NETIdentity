using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP.NETIdentity.Models.Demo
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public City City { get; set; }

        public Country Country{ get; set; }

        //public Country Country { get; set; }
    }
}