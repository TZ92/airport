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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Web.Controllers
{
    [Authorize(Roles = "Administrator,EmployeeAirline")]
    public class ReservationController : Controller
    {
        private Context db = new Context();

        IReservationService rse = new ReservationService();

        public ReservationController(IReservationService rse)
        {
            this.rse = rse;
        }

        public ReservationController()
        {
        }


        // GET: Reservation
        public ActionResult Index()
        {
            var x = rse.getAllReservation();
            return View(x);
        }

        // GET: Reservation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reservation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reservation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReservationId,DateReservation,Status,TravelClass,ClientId,FlightId")] Reservation Reservation)
        {
            if (ModelState.IsValid)
            {
                db.Reservations.Add(Reservation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Reservation);
        }

        // GET: Reservation/Edit/5
        public ActionResult Edit(int? id)
        {
            {

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Reservation reservation = db.Reservations.Find(id);
                if (reservation == null)
                {
                    return HttpNotFound();
                }
                return View(reservation);


            }
        }

        // POST: Reservation/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReservationId,DateReservation,Status,TravelClass,ClientId,FlightId")] Reservation reservation)
        {

            if (ModelState.IsValid)
            {
                Reservation x = rse.GetById(reservation.ReservationId);
                x.DateReservation = reservation.DateReservation;
                x.Status = reservation.Status;
                x.TravelClass = reservation.TravelClass;
                x.ClientId = reservation.ClientId;
                x.FlightId = reservation.FlightId;
                rse.Update(x);
                rse.Commit();
                return RedirectToAction("Index");
            }
            return View(reservation);

        }

        // GET: Reservation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation Reservation = db.Reservations.Find(id);
            if (Reservation == null)
            {
                return HttpNotFound();
            }
            return View(Reservation);
        }

        // POST: Reservation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservation Reservation = db.Reservations.Find(id);
            db.Reservations.Remove(Reservation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        private String randomchar()
        {
            String alphabet = "0123456789ABCDE";
            int N = alphabet.Length;
            Random r = new Random();
            String text = "";
            for (int i = 0; i < 10; i++)
            {
                text += (alphabet.ElementAt(r.Next(N)));
            }
            return text;
        }






        public ActionResult DownloadActionAsPDF()
        {
            try
            {
                //will take ActionMethod and generate the pdf
                return new Rotativa.ActionAsPdf("Index") { FileName = "Reservations( " + DateTime.Now + " ).pdf" };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public ActionResult PDF(int id)
        {
            Reservation r = rse.GetById(id);
            var x = randomchar();
            Document doc = new Document(iTextSharp.text.PageSize.A4, 10, 10, 10, 10);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("C:\\Users\\Ala\\Desktop\\PDF" + x + ".pdf", FileMode.Create));
            doc.Open();
            Paragraph p = new Paragraph("RESERVATION DETAILS");
            p.Alignment = Element.ALIGN_CENTER;
            doc.Add(p);
            Image img = Image.GetInstance("C:\\Users\\Ala\\Desktop\\tayara.jpg");
            img.Alignment = Element.ALIGN_RIGHT;
            doc.Add(img);
            p = new Paragraph("Reservation ID: " + r.ReservationId);
            // p.Alignment = Element.ALIGN_JUSTIFIED;
            doc.Add(p);
            p = new Paragraph("Client ID  :" + r.ClientId);
            //  p.Alignment = Element.ALIGN_LEFT;
            doc.Add(p);
            p = new Paragraph("Reservation Status  :" + r.Status);
            //  p.Alignment = Element.ALIGN_LEFT;
            doc.Add(p);
            p = new Paragraph("Travel CLass:" + r.TravelClass);
            // p.Alignment = Element.ALIGN_RIGHT;
            doc.Add(p);
            p = new Paragraph("Brand:" + r.FlightId);
            // p.Alignment = Element.ALIGN_RIGHT;
            doc.Add(p);
            p = new Paragraph("Reservation Date:" + r.DateReservation); 
            // p.Alignment = Element.ALIGN_RIGHT;
            doc.Add(p);
            doc.Close();
            System.Diagnostics.Process.Start("C:\\Users\\Ala\\Desktop\\PDF" + x + ".pdf");
            //return (Content("<script language='javascript' type='text/javascript'>alert('Download Successfull');</script>"));
            return RedirectToAction("Index");
        }

    }
}
