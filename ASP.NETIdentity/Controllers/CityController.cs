using ASP.NETIdentity.Models;
using ASP.NETIdentity.Models.Demo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NETIdentity.Controllers
{
    [Authorize(Roles = "Admins")]
    public class CityController : Controller
    {

        PeopleDBModelContext db = new PeopleDBModelContext();

        public ActionResult Index()
        {
            return View(db.Cities.Include("Country").Include("People").ToList());
        }


        public ActionResult Details(int id)
        {
            var City = db.Cities.Include("Country").Include("People").SingleOrDefault(c => c.CityId == id);
            if (City== null)
            {
                return HttpNotFound();
            }
            return View(City);
        }


        public ActionResult Create()
        {
            ViewBag.CountryName = new SelectList(db.Countries, "CountryId", "ContryName");
            //ViewBag.CountryName = db.Countries.Select(s => new Country { CountryId = s.CountryId, ContryName = s.ContryName });
            return View();
        }


        [HttpPost]
        public ActionResult Create(CityViewModel city)
        {
            try
            {
                City City=new City();
                if (ModelState.IsValid)
                {
                    City.CityName = city.Name;
                    City.Country = db.Countries.SingleOrDefault(c => c.CountryId == city.CountryName);
                    db.Cities.Add(City);
                    db.SaveChanges();

                    //ViewBag.CountryName = new SelectList(db.Countries, "CountryId", "ContryName");
                    return RedirectToAction("Index");
                }
                return View(city);

            }
            catch
            {
                return View();
            }
        }


        public ActionResult Edit(int id)
        {
            var City = db.Cities.Include("Country").SingleOrDefault(c =>c.CityId  == id);
            ViewBag.CountryName = new SelectList(db.Countries, "CountryId", "ContryName");
            
            if (City == null)
            {
                return HttpNotFound();
            }
            return View(City);
        }


        [HttpPost]
        public ActionResult Edit(City city)
        {
            try
            {
                City City = db.Cities.Find(city.CityId);

                if (ModelState.IsValid)
                {
                    City.CityName = city.CityName;
                    City.CountryId = city.CountryId;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(city);
            }
            catch
            {
                return View(city);
            }
        }

        // GET: Role/Delete/5
        public ActionResult Delete(int id)
        {
            var City = db.Cities.Include("Country").Include("People").SingleOrDefault(c => c.CityId == id);
            if (City == null)
            {
                return HttpNotFound();
            }
            return View(City);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,City city)
        {
            try
            {
                // TODO: Add delete logic here
                City City = db.Cities.Include("Country").Include("People").SingleOrDefault(c => c.CityId == id);
                var people = db.People.Where(p => p.City.CityId == City.CityId).ToList();
                if (people.Count > 0)
                {
                    ViewBag.msg = "Error: Can't remove City if people still live in it";
                    return View(City);
                }
                else
                {
                    db.Cities.Remove(City);
                    db.SaveChanges();
                }
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}