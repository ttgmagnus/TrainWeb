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
    /// CarriageController controls http and db requests related to train Carriage.
    /// </summary>
    [Authorize(Roles = "Admin")]
    public class CarriageController : Controller
    {
        //create a database context.
        private ApplicationDbContext db = new ApplicationDbContext();

        /// <summary>
        /// ActionResult returns values of Carriage back to view. 
        /// </summary>
        /// <returns>Returns db.CarriageModels as a list to view.</returns>
        public ActionResult Index()
        {
            var carriageModels = db.CarriageModels.Include(c => c.Tickets);
            return View(carriageModels.ToList());
        }

        /// <summary>
        /// Checks if it is possible to view details on Carriage from database based on ID.
        /// </summary>
        /// <param name="id">ID corresponds to PK in database.</param>
        /// <returns>The details CarriageModel view with datavalues that have ID as PK</returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarriageModel carriageModel = db.CarriageModels.Find(id);
            if (carriageModel == null)
            {
                return HttpNotFound();
            }
            return View(carriageModel);
        }

        /// <summary>
        /// Opens a new create Carriage view
        /// </summary>
        /// <returns>Return a create Carriage view.</returns>
        public ActionResult Create()
        {
            ViewBag.TicketId = new SelectList(db.TicketModels, "Id", "Id");
            return View();
        }

        /// <summary>
        /// Creates Carriage data and sends to database.
        /// 
        /// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        /// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /// </summary>
        /// <param name="CarriageModel">List of database values.</param>
        /// <returns>The index Carriage view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TicketId,Name,Type,Weight,Height,Width,Length,Description")] CarriageModel carriageModel)
        {
            if (ModelState.IsValid)
            {
                db.CarriageModels.Add(carriageModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TicketId = new SelectList(db.TicketModels, "Id", "Id", carriageModel.TicketId);
            return View(carriageModel);
        }

        /// <summary>
        /// Checks if it is possible to edit Carriage from database based on ID.
        /// </summary>
        /// <param name="id">ID corresponds to PK in database.</param>
        /// <returns>The edit Carriage view with a list of datavalues that have ID as PK</returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarriageModel carriageModel = db.CarriageModels.Find(id);
            if (carriageModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.TicketId = new SelectList(db.TicketModels, "Id",  "Id", carriageModel.TicketId);
            return View(carriageModel);
        }

        /// <summary>
        /// Edit Carriage data from database based on the list CarriageModel.
        /// 
        /// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        /// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /// </summary>
        /// <param name="CarriageModel">List of database values.</param>
        /// <returns>The index Carriage view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TicketId,Name,Type,Weight,Height,Width,Length,Description")] CarriageModel carriageModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carriageModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TicketId = new SelectList(db.TicketModels, "Id", "Id", carriageModel.TicketId);
            return View(carriageModel);
        }

        /// <summary>
        /// Checks if it is possible to delete Carriage from database based on ID.
        /// </summary>
        /// <param name="id">ID corresponds to PK in database.</param>
        /// <returns>The delete Carriage view with a list of datavalues that have ID as PK</returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarriageModel carriageModel = db.CarriageModels.Find(id);
            if (carriageModel == null)
            {
                return HttpNotFound();
            }
            return View(carriageModel);
        }

        /// <summary>
        /// Delete Carriage data from database that has ID as PK
        /// </summary>
        /// <param name="id">ID corresponds to PK in database</param>
        /// <returns>The index Carriage view</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarriageModel carriageModel = db.CarriageModels.Find(id);
            db.CarriageModels.Remove(carriageModel);
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
