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
using System.IO;
using Data.Models;
using Service;

namespace Web.Controllers
{
    [Authorize(Roles = "Administrator,Employee")]
    public class AirlinesController : Controller
    {
        private Context db = new Context();

       
        IAirlineManagementService pse = new AirlineManagementService();

        public AirlinesController(IAirlineManagementService pse)
        {
            this.pse = pse;
        }

        public AirlinesController()
        {
        }

        // GET: EmpAirlines

        [HttpPost]
        public ActionResult Index(String Search)
        {
            var l = pse.GetAirlineByName(Search);
            return View(l);
        }
        public ActionResult Index()
        {
            var l = pse.GetMany();
            return View(l.ToList());
        }

        // GET: EmpAirlines/Details/5
        public ActionResult Details(int? id)
        {
            IEnumerable<EmpAirline> empAirline = pse.EmployesByAirline((int)id);
            ViewBag.empAirline = empAirline;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Airlinecompany Airline = pse.getAirlineById((int)id);
            if (Airline == null)
            {
                return HttpNotFound();
            }
            return View(Airline);
        }

        // GET: EmpAirlines/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Airlines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AirlinecompanyId,Address,Longitude,Latitude,Continent,Contry,Logo,Name,Phone,SiteWeb")] Airlinecompany airline, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid || (Image == null) || (Image.ContentLength == 0))
            {
                airline.Logo = Image.FileName;
                pse.AddAirline(airline);
                db.SaveChanges();
                var path = Path.Combine(Server.MapPath("~/Content/Upload/") + Image.FileName);
                Image.SaveAs(path);
                return RedirectToAction("Index");
            }

            return View(airline);
        }

        // GET: Airlines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Airlinecompany Airline = pse.getAirlineById((int)id);
            if (Airline == null)
            {
                return HttpNotFound();
            }
            return View(Airline);
        }

        // POST: Airlines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormCollection collection)
        {

            Airlinecompany a = pse.getAirlineById(id);
            a.Address = collection["Address"];
            a.Longitude = collection["Longitude"];
            a.Latitude = collection["Latitude"];
            a.Continent = collection["Continent"];
            a.Contry = collection["Contry"];
            a.Name = collection["Name"];
            a.Phone = collection["Phone"];
            a.SiteWeb = collection["SiteWeb"];

            pse.Update(a);

            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View(a);
            }

        }
        [HttpPost]
        public ActionResult EditImage([Bind(Include = "AirlinecompanyId,Logo")] Airlinecompany airline, HttpPostedFileBase Image)
        {
            
            
                if( (Image == null) || (Image.ContentLength == 0))
                {

                }
                else
                {
                    Airlinecompany a = pse.getAirlineById(airline.AirlinecompanyId);
                    a.Logo = Image.FileName;
                    var path = Path.Combine(Server.MapPath("~/Content/Upload/") + Image.FileName);
                    Image.SaveAs(path);
                    pse.Update(a);
                    pse.Commit();
                    return RedirectToAction("Index");
                }

                
           
            return View(airline);
        }


        // GET: Airlines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Airlinecompany airline = pse.getAirlineById((int)id);
            if (airline == null)
            {
                return HttpNotFound();
            }
            return View(airline);
        }

        // POST: Airlines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Airlinecompany airline = pse.getAirlineById((int)id);
            pse.Delete(airline);
            pse.Commit();
            return RedirectToAction("Index");
        }


        public ActionResult ChartArrayBasic()
        {
            //ViewBag.x = new[] { "Peter", "Andrew", "Julie", "Mary", "Dave" };
            //ViewBag.y = new[] { "2", "6", "4", "5", "3" };

            List<String> s = new List<string>();
            List<int?> s2 = new List<int?>();

            var l = pse.getAllAirline();
            
            foreach (var x in l)
            {
                s.Add(x.Name);
                s2.Add(x.Rate);
            }
            ViewBag.x = s;
            ViewBag.y = s2;


            return View();
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult DisplayChart()
        {
           
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
