using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrainTicketBooking.Data;

namespace TrainTicketBooking.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TicketController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Ticket
        public ActionResult Index()
        {
            var ticketModels = db.TicketModels.Include(t => t.Trains);
            return View(ticketModels.ToList());
        }

        // GET: Admin/Ticket/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketModel ticketModel = db.TicketModels.Find(id);
            if (ticketModel == null)
            {
                return HttpNotFound();
            }
            return View(ticketModel);
        }

        // GET: Admin/Ticket/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID= new SelectList(db.Users, "UserName", "UserName");
            ViewBag.TrainId = new SelectList(db.TrainsModels, "Id", "TrainName");
            return View();
        }

        // POST: Admin/Ticket/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TrainId,TrainType,OrderDate,Price,StationFrom,StationTo,TravelDate,CustomerID,Issuedby")] TicketModel ticketModel)
        {
            if (ModelState.IsValid)
            {
                db.TicketModels.Add(ticketModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Users, "UserName", "UserName");
            ViewBag.TrainId = new SelectList(db.TrainsModels, "Id", "TrainName", ticketModel.TrainId);
            return View(ticketModel);
        }

        // GET: Admin/Ticket/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketModel ticketModel = db.TicketModels.Find(id);
            if (ticketModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Users, "UserName", "UserName");
            ViewBag.TrainId = new SelectList(db.TrainsModels, "Id", "TrainName", ticketModel.TrainId);
            return View(ticketModel);
        }

        // POST: Admin/Ticket/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TrainId,TrainType,OrderDate,Price,StationFrom,StationTo,TravelDate,CustomerID,Issuedby")] TicketModel ticketModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticketModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Users, "UserName", "UserName");
            ViewBag.TrainId = new SelectList(db.TrainsModels, "Id", "TrainName", ticketModel.TrainId);
            return View(ticketModel);
        }

        // GET: Admin/Ticket/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketModel ticketModel = db.TicketModels.Find(id);
            if (ticketModel == null)
            {
                return HttpNotFound();
            }
            return View(ticketModel);
        }

        // POST: Admin/Ticket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TicketModel ticketModel = db.TicketModels.Find(id);
            db.TicketModels.Remove(ticketModel);
            db.SaveChanges();
            return RedirectToAction("Index");
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
