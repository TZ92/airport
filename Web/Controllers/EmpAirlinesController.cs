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
using System.IO;
using System.Net.Mail;

namespace Web.Controllers
{
    [Authorize(Roles = "Administrator,Employee")]
    public class EmpAirlinesController : Controller
    {
        private Context db = new Context();
        IEmpAirlineManagementService pse = new EmpAirlineManagementService();
        IAirlineManagementService ams = new AirlineManagementService();

        public EmpAirlinesController(IEmpAirlineManagementService pse)
        {
            this.pse = pse;
        }

        public EmpAirlinesController()
        {
        }

        // GET: EmpAirlines
        public ActionResult Index()
        {
            var l = pse.GetMany();
            return View(l.ToList());
            
        }
        [HttpPost]
        public ActionResult Index(String Search)
        {
            var l = pse.GetEmpAirlineByName(Search);
            return View(l);
        }

        // GET: EmpAirlines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpAirline empAirline = pse.getEmpAirlineById((int)id);
            if (empAirline == null)
            {
                return HttpNotFound();
            }
            return View(empAirline);
        }

        // GET: EmpAirlines/Create
        public ActionResult Create()
        {
            IEnumerable<Airlinecompany> Airlinecompanys = ams.GetMany().ToList();
            ViewBag.Airlinecompanys = Airlinecompanys;
            return View();
        }

        // POST: EmpAirlines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpAirlineId,Address,Contry,Image,Firstname,Lastname,Phone,CIN,Email,AirlinecompanyId")] EmpAirline empAirline, HttpPostedFileBase Image)
        {
            IEnumerable<Airlinecompany> Airlinecompanys = ams.GetMany().ToList();
            ViewBag.Airlinecompanys = Airlinecompanys;

           
            if (ModelState.IsValid || (Image == null) || (Image.ContentLength == 0))
            {
                empAirline.Image = Image.FileName;
                pse.AddEmpAirline(empAirline);
                db.SaveChanges();
                var path = Path.Combine(Server.MapPath("~/Content/Upload/") + Image.FileName);
                Image.SaveAs(path);
                return RedirectToAction("Index");
            }
            
            return View(empAirline);
        }

        // GET: EmpAirlines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpAirline empAirline = pse.getEmpAirlineById((int)id);
            if (empAirline == null)
            {
                return HttpNotFound();
            }
            return View(empAirline);
        }

        // POST: EmpAirlines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormCollection collection)
        {

            EmpAirline a = pse.getEmpAirlineById(id);
            a.Address = collection["Address"];
            a.Contry = collection["Contry"];
            a.Firstname = collection["Firstname"];
            a.Lastname = collection["Lastname"];
            a.Phone = collection["Phone"];
            a.CIN = long.Parse(collection["CIN"]);
            a.Email = collection["Email"];


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
        public ActionResult EditImage([Bind(Include = "EmpAirlineId,Image")] EmpAirline empAirline, HttpPostedFileBase Image)
        {


            if ((Image == null) || (Image.ContentLength == 0))
            {

            }
            else
            {
                EmpAirline a = pse.getEmpAirlineById(empAirline.EmpAirlineId);
                a.Image = Image.FileName;
                var path = Path.Combine(Server.MapPath("~/Content/Upload/") + Image.FileName);
                Image.SaveAs(path);
                pse.Update(a);
                pse.Commit();
                return RedirectToAction("Index");
            }



            return View(empAirline);
        }

        // GET: EmpAirlines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpAirline empAirline = pse.getEmpAirlineById((int)id);
            if (empAirline == null)
            {
                return HttpNotFound();
            }
            return View(empAirline);
        }

        

        // POST: EmpAirlines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmpAirline empAirline = pse.getEmpAirlineById((int)id);
            pse.Delete(empAirline);
            pse.Commit();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult SendMail(FormCollection  formCollection)
        {
             
            String to = formCollection["to"];
            String cc = Request.Form["cc"];
            String body = Request.Form["body"];

            System.Diagnostics.Debug.WriteLine("SomeText "+ formCollection["to"]+ " "+ cc+ " "+ formCollection["cc"]);


            using (MailMessage mail = new MailMessage("falloussaf@gmail.com", to))
            {

                mail.Subject = cc;
                mail.Body = body;

                mail.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential networkCredential = new NetworkCredential("falloussaf@gmail.com", "wassimboussetta");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = networkCredential;
                smtp.Port = 25;
                smtp.Send(mail);
                ViewBag.Message = "Sent";
                return RedirectToAction("Index");
            }
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
 