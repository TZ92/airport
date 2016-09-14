using Data.Models;
using Domain.Entities;
using Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web.Models;




namespace Web.Controllers
{
    [Authorize(Roles = "Administrator,Employee")]
    public class DealController : Controller
    {
     

        IDealService pse = new DealService();

        public DealController(IDealService pse)
        {
            this.pse = pse;
        }

        public DealController()
        {
        }


        // GET:Deal
        public ActionResult Index()
        {

            var l = pse.GetMany();
            return View(l.ToList());
    
        }

        // GET: Deal/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Deal deal = pse.getDealById((int)id);
            if (deal == null)
            {
                return RedirectToAction("Index");
            }
            return View(deal);
        }

        public ActionResult Create()
        {
            DealViewModel dealVM = new DealViewModel();
            //dealVM.Flights = pse.GetAllFlight().ToSelectListItem();

            return View(dealVM);
        }

        // POST: Film/Create
        [HttpPost]
        public ActionResult Create(DealViewModel dealVM)
        {


          Deal deal = new Deal
            {


              Description = dealVM.Description,
            Active = dealVM.Active,
            StartDeal = dealVM.StartDeal,
           EndDeal = dealVM.EndDeal,
         
            FlightId = dealVM.FlightId,

          
            };

            pse.AddDeal(deal);
            pse.Commit();

          //  var path = Path.Combine(Server.MapPath("~/Content/Upload"), Image.FileName);
          //  Image.SaveAs(path);
           return RedirectToAction("Index");
        }


        // GET: Deal/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deal deal = pse.GetById((int)id);
            if (deal == null)
            {
                return HttpNotFound();
            }
            return View(deal);
        }

        // POST:  Deal/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DealId,Description,Active,StartDeal,EndDeal,FlightId")] Deal deal)
        {
            if (ModelState.IsValid)
            {
               Deal x = pse.GetById(deal.DealId);
                x.Description= deal.Description;
                x.Active = deal.Active;
                x.StartDeal= deal.StartDeal;
                x.EndDeal = deal.EndDeal;
          
                x.FlightId = deal.FlightId;
                pse.Update(x);
                pse.Commit();
                return RedirectToAction("Index");
            }
            return View(deal);
        }

        // GET: Deal/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deal deal = pse.GetById((int)id);
            if (deal == null)
            {
                return HttpNotFound();
            }
            return View(deal);
        }

      
        // POST: /Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Deal deal = pse.GetById((int)id);
            pse.Delete(deal);
            pse.Commit();
  
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
              
            }
            base.Dispose(disposing);
        }
    }
}