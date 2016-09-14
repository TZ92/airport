using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data;
using Domain.Entities;
using Data.Models;
using Service;

namespace Web.Controllers
{
     [Authorize(Roles ="Administrator,EmployeeAirline")]
    public class PlaneController : Controller
    {

        IPlaneService pse = new PlaneService();

        public PlaneController(IPlaneService pse)
        {
            this.pse = pse;
        }

        public PlaneController()
        {
        }


        // GET: Plane
        public ActionResult Index()
        {

            var l = pse.GetMany();
            return View(l.ToList());
        }

        // GET: Plane/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Plane plane = pse.GetById((int)id);
            if (plane == null)
            {
                return RedirectToAction("Index");
            }
            return View(plane);
        }

        // GET: Plane/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Plane/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlaneId,totalSeats,maximumSpeed,planeName,plug,wifi")] Plane plane)
        {
            if (ModelState.IsValid)
            {
                pse.Add(plane);
                pse.Commit();
//                db.Planes.Add(plane);
//                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(plane);
        }

        // GET: Plane/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plane plane = pse.GetById((int)id);
            if (plane == null)
            {
                return HttpNotFound();
            }
            return View(plane);
        }

        // POST: Plane/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlaneId,totalSeats,maximumSpeed,planeName,plug,wifi")] Plane plane)
        {
            if (ModelState.IsValid)
            {
                Plane x = pse.GetById(plane.PlaneId);
                x.TotalSeats = plane.TotalSeats;
                x.MaximumSpeed = plane.MaximumSpeed;
                x.PlaneName = plane.PlaneName;
                x.Plug = plane.Plug;
                x.Wifi = plane.Wifi;
                pse.Update(x);
                pse.Commit();
                return RedirectToAction("Index");
            }
            return View(plane);
        }

        // GET: Plane/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plane plane = pse.GetById((int)id);
            if (plane == null)
            {
                return HttpNotFound();
            }
            return View(plane);
        }

    

        // POST: Plane/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Plane plane = pse.GetById((int)id);
            pse.Delete(plane);
            pse.Commit();
//            db.Planes.Remove(plane);
//            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //pse.Dispose()
            }
            base.Dispose(disposing);
        }
    }
}
