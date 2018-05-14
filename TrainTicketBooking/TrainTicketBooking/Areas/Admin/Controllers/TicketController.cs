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
    /// <summary>
    /// TicketController controls http and db requests related to ticket booking
    /// </summary>
    [Authorize(Roles = "Admin")]
    public class TicketController : Controller
    {
        // create a db context
        private ApplicationDbContext db = new ApplicationDbContext();

        /// <summary>
        /// ActionResult returns values of ticketbooking back to view
        /// </summary>
        /// <returns>Returns ticketmodels as a list to view</returns>
        public ActionResult Index()
        {
            var ticketModels = db.TicketModels.Include(t => t.Trains);
            return View(ticketModels.ToList());
        }

        /// <summary>
        /// Checks if it is possible to view details on tickets from database based on ID.
        /// </summary>
        /// <param name="id">ID corresponds to PK in database.</param>
        /// <returns>The details ticketModel view with datavalues that av ID as PK</returns>
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

        /// <summary>
        /// Create a ticket view based on database values from customer- and train lists.
        /// </summary>
        /// <returns>A ticket view.</returns>
        public ActionResult Create()
        {
            ViewBag.CustomerID= new SelectList(db.Users, "UserName", "UserName");
            ViewBag.TrainId = new SelectList(db.TrainsModels, "Id", "TrainName");
            return View();
        }

        /// <summary>
        /// Creates ticket data and sends to database.
        /// 
        /// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        /// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /// </summary>
        /// <param name="TicketModel">List of database values.</param>
        /// <returns>The index ticket view</returns>
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
        
        /// <summary>
        /// Checks if it is possible to edit tickets from database based on ID.
        /// </summary>
        /// <param name="id">ID corresponds to PK in database.</param>
        /// <returns>The edit tickets view with datavalues that have ID as PK</returns>
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

        /// <summary>
        /// Edit ticket data from database based on the list TicketModel.
        /// 
        /// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        /// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /// </summary>
        /// <param name="TicketModel">List of database values</param>
        /// <returns>The index ticket view</returns>
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

        /// <summary>
        /// Checks if it is possible to delete routes from database based on ID.
        /// </summary>
        /// <param name="id">ID corresponds to PK in database.</param>
        /// <returns>The delete ticket view with a list of datavalues that have ID as PK</returns>
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

        /// <summary>
        /// Delete Ticket data from database that has ID as PK
        /// </summary>
        /// <param name="id">ID corresponds to PK in database</param>
        /// <returns>The index ticket view</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TicketModel ticketModel = db.TicketModels.Find(id);
            db.TicketModels.Remove(ticketModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Release unmanaged database resources 
        /// </summary>
        /// <param name="disposing">Bool value true or false</param>
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
