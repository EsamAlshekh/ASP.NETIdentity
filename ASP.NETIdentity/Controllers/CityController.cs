using ASP.NETIdentity.Models.Demo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NETIdentity.Controllers
{
    public class CityController : Controller
    {

        PeopleDBModelContext db = new PeopleDBModelContext();

        public ActionResult Index()
        {
            return View(db.Cities.ToList());
        }


        public ActionResult Details(int id)
        {
            var City = db.Cities.Find(id);
            if (City== null)
            {
                return HttpNotFound();
            }
            return View(City);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(City city)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Cities.Add(city);
                    db.SaveChanges();
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

            var City = db.Cities.Find(id);
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

                if (ModelState.IsValid)
                {
                    db.Entry(city).State = EntityState.Modified;
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
            var City = db.Cities.Find(id);
            if (City == null)
            {
                return HttpNotFound();
            }
            return View(City);

        }


        [HttpPost]
        public ActionResult Delete(int id,City city)
        {
            try
            {
                // TODO: Add delete logic here
                City City = db.Cities.Find(id);
                db.Cities.Remove(City);
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