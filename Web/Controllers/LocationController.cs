using Domain.Entities;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Web.Content
{
    [Authorize(Roles = "Administrator,Employee")]
    public class LocationController : Controller
    {
        ILocationService loc = new LocationService();
        // GET: Location
        public ActionResult Index()
        {
            IEnumerable<Location> listlocation = loc.GetMany();
            return View(listlocation);
        }

        // GET: Location/Details/5
        public ActionResult Details(int id)
        {
            Location location = loc.GetById(id);
            return View(location);
        }

        // GET: Location/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Location/Create
        [HttpPost]
        public ActionResult Create(Location l)
        {
            loc.Add(l);
            loc.Commit();
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Location/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location Location = loc.GetById(id);
            if (Location == null)
            {
                return HttpNotFound();
            }
            return View(Location);
        }

        // POST: Location/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LocationId,AirportCode,AirportName,City,Country,TimeZone,ZipCode")] Location location)
        {
            if (ModelState.IsValid)
            {
                Location x = loc.GetById(location.LocationId);
                x.AirportCode = location.AirportCode;
                x.AirportName = location.AirportName;
                x.City = location.City;
                x.Country = location.Country;
                x.TimeZone = location.TimeZone;
                x.ZipCode = location.ZipCode;
                loc.Update(x);
                loc.Commit();
                return RedirectToAction("Index");
            }
            return View(location);

        }

        // GET: Location/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location l = loc.GetById(id);
            if (l == null)
            {
                return HttpNotFound();
            }
            return View(l);


           
        }

      


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            Location l = loc.GetById(id);
            loc.Delete(l);
            loc.Commit();
            return RedirectToAction("Index");
        }
    }
}
