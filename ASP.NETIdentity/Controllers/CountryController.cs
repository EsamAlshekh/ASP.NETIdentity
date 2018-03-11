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
    public class CountryController : Controller
    {
        PeopleDBModelContext db = new PeopleDBModelContext();
        
        public ActionResult Index()
        {
            return View(db.Countries.Include("cities").ToList());
        }

        
        public ActionResult Details(int id)
        {
            var Country = db.Countries.Include("cities").SingleOrDefault(s => s.CountryId == id);
            if (Country == null)
            {
                return HttpNotFound();
            }
            return View(Country);
        }

        
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult Create(Country country)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Countries.Add(country);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(country);

            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult Edit(int id)
        {

            var Country = db.Countries.Include("cities").SingleOrDefault(s => s.CountryId == id);
            if (Country == null)
            {
                return HttpNotFound();
            }
            return View(Country);
        }

       
        [HttpPost]
        public ActionResult Edit(Country country)
        {
            try
            {
                
                if (ModelState.IsValid)
                {
                    db.Entry(country).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(country);
            }
            catch
            {
                return View(country);
            }
        }

        // GET: Role/Delete/5
        public ActionResult Delete(int id)
        {
            var Country = db.Countries.Include("cities").SingleOrDefault(s => s.CountryId == id);
            if (Country == null)
            {
                return HttpNotFound();
            }
            return View(Country);

        }

        
        [HttpPost]
        public ActionResult Delete(int id,Country country)
        {
            try
            {
                // TODO: Add delete logic here
                var Country = db.Countries.Include("cities").SingleOrDefault(s => s.CountryId == id);
               // var City = db..Where(p => p.City.CityId == City.CityId).ToList();
                if (Country.cities.Count()>0)
                {
                    ViewBag.msg = "Error: Can't remove Country if city still there in it";
                    return View(Country);
                }
                else
                {
                    db.Countries.Remove(Country);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                
            }
            catch
            {
                return View();
            }
        }
    }
}