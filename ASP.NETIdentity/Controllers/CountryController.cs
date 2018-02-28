using ASP.NETIdentity.Models.Demo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NETIdentity.Controllers
{
    public class CountryController : Controller
    {
        PeopleDBModelContext db = new PeopleDBModelContext();
        
        public ActionResult Index()
        {
            return View(db.Countries.ToList());
        }

        
        public ActionResult Details(string id)
        {
            var Country = db.Countries.Find(id);
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

        
        public ActionResult Edit(string id)
        {

            var Country = db.Countries.Find(id);
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
        public ActionResult Delete(string id)
        {
            var Country = db.Countries.Find(id);
            if (Country == null)
            {
                return HttpNotFound();
            }
            return View(Country);

        }

        
        [HttpPost]
        public ActionResult Delete(Country country)
        {
            try
            {
                // TODO: Add delete logic here
                Country Country = db.Countries.Find(country.CountryId);
                db.Countries.Remove(Country);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}