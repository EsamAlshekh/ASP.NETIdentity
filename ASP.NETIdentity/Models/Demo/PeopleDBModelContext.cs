using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASP.NETIdentity.Models.Demo
{
    public class PeopleDBModelContext : DbContext
    {
       
        
            public PeopleDBModelContext() : base("name=DefaultConnection")
            {
            }

            public DbSet<Person> People { get; set; }
            public DbSet<City> Cities { get; set; }
            public DbSet<Country> Countries { get; set; }

        public System.Data.Entity.DbSet<ASP.NETIdentity.Models.Demo.PersonViewmodel> PersonViewmodels { get; set; }
    }
}