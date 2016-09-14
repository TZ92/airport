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
using Web.Models;

namespace Web.Controllers
{
    [Authorize(Roles = "Administrator,EmployeeAirline")]
    public class FlightController : Controller
    {


        IFlightService fse = new FlightService();
        ILocationService lse = new LocationService();
        IPlaneService pse = new PlaneService();
        IAirlineManagementService ase = new AirlineManagementService();
        public FlightController(IFlightService fse)
        {
            this.fse = fse;
        }

        public FlightController()
        {
        }


        // GET: EmpAirlines
        public ActionResult Index()
        {
            var flights = fse.GetMany();
            return View(flights.ToList());

        }

        // GET: Flight/Create
        public ActionResult Create()
        {
            IEnumerable<Location> locations = lse.GetMany().ToList();
            IEnumerable<Plane> planes = pse.GetMany().ToList();
            IEnumerable<Airlinecompany> airlinecompanys = ase.GetMany().ToList();
            ViewBag.planes = planes;
            ViewBag.locations = locations;
            ViewBag.airlinecompanys = airlinecompanys;
            return View();
        }

        // POST: Flight/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "FlightId,Number,ActualArrival,ActualDeparture,ArrivalDate,DepartDate,AvailableSeats,FlightDuration,FlightMiles,FlightStatus,MilesParcoured,NumberStops,price,DepartLocationId,ArrivalLocationId,PlaneId")] Flight flight)
        public ActionResult Create(Flight model)
        {
            Flight f = new Flight
            {
                Number = model.Number,
                DepartLocationId = model.DepartLocationId,
                ArrivalLocationId = model.ArrivalLocationId,
                price = model.price,
                ArrivalDate = model.ArrivalDate,
                DepartDate = model.DepartDate,
                NumberStops = (int)model.NumberStops,
                FlightDuration = (int)model.FlightDuration,
                FlightMiles = (int)model.FlightMiles,
                PlaneId = model.PlaneId,
                AirlinecompanyId=model.AirlinecompanyId
            };
            IEnumerable<Location> locations = lse.GetMany().ToList();
            IEnumerable<Plane> planes = pse.GetMany().ToList();
            IEnumerable<Airlinecompany> airlinecompanys = ase.GetMany().ToList();
            ViewBag.locations = locations;
            ViewBag.planes = planes;
            ViewBag.airlinecompanys = airlinecompanys;
            if (ModelState.IsValid)
            {

                fse.Add(f);
                fse.Commit();
                return RedirectToAction("Index");
            }

            return View(model);
        }


        // GET: Plane/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Flight flight = fse.GetById((int)id);
            if (flight == null)
            {
                return RedirectToAction("Index");
            }
            return View(flight);
        }



        // GET: Plane/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = fse.GetById((int)id);
            IEnumerable<Location> locations = lse.GetMany().ToList();
            IEnumerable<Plane> planes = pse.GetMany().ToList();
            IEnumerable<Airlinecompany> airlinecompanys = ase.GetMany().ToList();
            ViewBag.locations = locations;
            ViewBag.planes = planes;
            ViewBag.airlinecompanys = airlinecompanys;

            if (flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // POST: Plane/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Flight flight)
        {
            IEnumerable<Location> locations = lse.GetMany().ToList();
            IEnumerable<Plane> planes = pse.GetMany().ToList();
            IEnumerable<Airlinecompany> airlinecompanys = ase.GetMany().ToList();
            ViewBag.locations = locations;
            ViewBag.planes = planes;
            ViewBag.airlinecompanys = airlinecompanys;
            if (ModelState.IsValid)
            {
                Flight x = fse.GetById(flight.FlightId);

                x.Number = flight.Number;
                x.DepartLocationId = flight.DepartLocationId;
                x.ArrivalLocationId = flight.ArrivalLocationId;
                x.price = flight.price;
                x.ArrivalDate = flight.ArrivalDate;
                x.DepartDate = flight.DepartDate;
                x.ActualArrival = flight.ActualArrival;
                x.ActualDeparture = flight.ActualDeparture;
                x.FlightStatus = flight.FlightStatus;
                x.AvailableSeats = flight.AvailableSeats;
                x.FlightDuration = flight.FlightDuration;
                x.FlightMiles = flight.FlightMiles;
                x.MilesParcoured = flight.MilesParcoured;
                x.NumberStops = flight.NumberStops;
                x.PlaneId = flight.PlaneId;
                x.AirlinecompanyId = flight.AirlinecompanyId;

                
                fse.Update(x);
                fse.Commit();
                return RedirectToAction("Index");
            }
            return View(flight);
        }

        // GET: Plane/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = fse.GetById((int)id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // POST: Plane/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Flight flight = fse.GetById((int)id);
            fse.Delete(flight);
            fse.Commit();
            //            db.Planes.Remove(plane);
            //            db.SaveChanges();
            return RedirectToAction("Index");
        }




        // GET: EmpAirlines
        public ActionResult FlightMap()
        {
            //var flights = fse.GetMany();
            var a = ase.GetMany();
            return View(a.ToList());

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
