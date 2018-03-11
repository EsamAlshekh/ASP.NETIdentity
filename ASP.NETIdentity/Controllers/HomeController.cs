using ASP.NETIdentity.Models;
using ASP.NETIdentity.Models.Demo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NETIdentity.Controllers
{
    [Authorize]
    public class HomeController : Controller
     {
            private PeopleDBModelContext db = new PeopleDBModelContext();
            public ActionResult Index(string orderBy)
            {
                List<Person> myList = new List<Person>();

            myList = db.People.Include("City").Include("City.Country").ToList();

                return View(myList);
            }
            
            public ActionResult Details(int id)
            {
                var Person = db.People.Include("City").Include("City.Country").SingleOrDefault(s => s.Id == id);
                if (Person == null)
                {
                    return HttpNotFound();
                }
                return View(Person);
            }

           
            public ActionResult Create()
            {
            PersonViewmodel vm = new PersonViewmodel();
            vm.Countrys = db.Countries.Include("cities").ToList();
            //ViewBag.CountryId= new SelectList(db.Countries, "CountryId", "ContryName").ToList();

            return View(vm);
            }


    [HttpPost]
            public ActionResult Create(PersonViewmodel person)
            {
           
            try
                {
                // TODO: Add insert logic here
                
                Person Person = new Person();
                
                if (ModelState.IsValid)
                    {
                    
                    Person.Name = person.Name;
                   // Person.Country.CountryId = person.Country.CountryId;
                    Person.CityId = person.CityId;
                        db.People.Add(Person);
                    db.SaveChanges();
                    //ViewBag.CountryName = new SelectList(db.Countries, "CountryId", "ContryName").ToList();
                    return RedirectToAction("Index");
                    }
                    return View(person);
                }
                catch
                {
                    return View(person);
                }

            }
            public JsonResult GitCityById(int id)
            {
            return Json(db.Cities.Where(s => s.Country.CountryId == id), JsonRequestBehavior.AllowGet);
            } 

            
            public ActionResult Edit(int id)
            {
           // PersonViewmodel vm = new PersonViewmodel();
            //vm.Countrys = db.Countries.ToList();
              ViewBag.CountryName = new SelectList(db.Countries, "CountryId", "ContryName");
                 var Person = db.People.Include("City").Include("City.Country").SingleOrDefault(s => s.Id == id); 
                return View(Person);
            }

            
            [HttpPost]
            public ActionResult Edit(int id, Person person)
            {

                try
                {
                
                // TODO: Add update logic here
                if (ModelState.IsValid)
                    {
                    var Person = db.People.Include("City").Include("City.Country").SingleOrDefault(s => s.Id == id);
                    Person.CityId = person.CityId;
                    Person.Name= person.Name;
                   // db.People.Add(Person);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                    }
                    return View(person);
                }
                catch
                {
                    return View(person);
                }
            }

            [Authorize(Roles ="Admins")]
            public ActionResult Delete(int id)
            {
                var Course = db.People.Find(id);
                return View(Course);
            }

           
            [HttpPost]
            public ActionResult Delete(int id, Person person)
            {
                try
                {
                    // TODO: Add delete logic here
                    var Person = db.People.Find(id);
                    db.People.Remove(Person);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(person);
                }
            }
        }
}