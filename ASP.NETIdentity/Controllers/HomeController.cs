using ASP.NETIdentity.Models;
using ASP.NETIdentity.Models.Demo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NETIdentity.Controllers
{
    public class HomeController : Controller
     {
            private PeopleDBModelContext db = new PeopleDBModelContext();
            public ActionResult Index(string orderBy)
            {
                List<Person> myList = new List<Person>();

            myList = db.People.ToList();

                return View(myList);
            }
            
            public ActionResult Details(int id)
            {
                var Person = db.People.SingleOrDefault(s => s.Id == id);
                if (Person == null)
                {
                    return HttpNotFound();
                }
                return View(Person);
            }

           
            public ActionResult Create()
            {
            ViewBag.CountryName = new SelectList(db.Countries, "CountryId", "ContryName");
            return View();
            }
        
            
            [HttpPost]
            public ActionResult Create(PersonViewModel person)
            {
            
                try
                {
                    // TODO: Add insert logic here
                    if (ModelState.IsValid)
                    {
                    Person Person = new Person();
                    Person.Name = person.Name;
                    Person.Country.CountryId = person.CountryId;
                    Person.City.CityId = person.CityId;
                        db.People.Add(Person);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    return View();
                }
                catch
                {
                    return View();
                }
            }

            
            public ActionResult Edit(int id)
            {
                var Course = db.People.Find(id);
                return View(Course);
            }

            
            [HttpPost]
            public ActionResult Edit(int id, PersonViewModel person)
            {

                try
                {
                    // TODO: Add update logic here
                    if (ModelState.IsValid)
                    {
                    Person Person = new Person();
                    Person.Name = person.Name;
                    Person.Country.CountryId = person.CountryId;
                    Person.City.CityId = person.CityId;
                    db.People.Add(Person);
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

            
            public ActionResult Delete(int id)
            {
                var Course = db.People.Find(id);
                return View(Course);
            }

           
            [HttpPost]
            public ActionResult Delete(int id, PersonViewModel person)
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