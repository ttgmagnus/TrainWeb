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
    /// ScheduleController controls http and db requests related to train schedule.
    /// </summary>
    [Authorize(Roles = "Admin")]
    public class ScheduleController : Controller
    {
        //create a database context.
        private ApplicationDbContext db = new ApplicationDbContext();

        /// <summary>
        /// ActionResult returns values of schedule back to view. 
        /// </summary>
        /// <returns>Returns db.scheduleModels as a list to view.</returns>
        public ActionResult Index()
        {
            var scheduleModels = db.ScheduleModels.Include(s => s.Stations).Include(s => s.Trains);
            return View(scheduleModels.ToList());
        }

        /// <summary>
        /// Checks if it is possible to view details on schedule from database based on ID.
        /// </summary>
        /// <param name="id">ID corresponds to PK in database.</param>
        /// <returns>The details scheduleModel view with datavalues that have ID as PK</returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleModel scheduleModel = db.ScheduleModels.Find(id);
            if (scheduleModel == null)
            {
                return HttpNotFound();
            }
            return View(scheduleModel);
        }

        /// <summary>
        /// Opens a new create schedule view
        /// </summary>
        /// <returns>Return a create schedule view.</returns>
        public ActionResult Create()
        {
            ViewBag.StationId = new SelectList(db.StationModels, "Id", "StationName");
            ViewBag.TrainId = new SelectList(db.TrainsModels, "Id", "TrainName");
            return View();
        }

        /// <summary>
        /// Creates schedule data and sends to database.
        /// 
        /// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        /// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /// </summary>
        /// <param name="scheduleModel">List of database values.</param>
        /// <returns>The index schedule view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TrainId,StationId,ArrivalTime,DepartureTime")] ScheduleModel scheduleModel)
        {
            if (ModelState.IsValid)
            {
                db.ScheduleModels.Add(scheduleModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StationId = new SelectList(db.StationModels, "Id", "StationName", scheduleModel.StationId);
            ViewBag.TrainId = new SelectList(db.TrainsModels, "Id", "TrainName", scheduleModel.TrainId);
            return View(scheduleModel);
        }

        /// <summary>
        /// Checks if it is possible to edit schedule from database based on ID.
        /// </summary>
        /// <param name="id">ID corresponds to PK in database.</param>
        /// <returns>The edit schedule view with a list of datavalues that have ID as PK</returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleModel scheduleModel = db.ScheduleModels.Find(id);
            if (scheduleModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.StationId = new SelectList(db.StationModels, "Id", "StationName", scheduleModel.StationId);
            ViewBag.TrainId = new SelectList(db.TrainsModels, "Id", "TrainName", scheduleModel.TrainId);
            return View(scheduleModel);
        }

        /// <summary>
        /// Edit schedule data from database based on the list ScheduleModel.
        /// 
        /// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        /// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /// </summary>
        /// <param name="ScheduleModel">List of database values.</param>
        /// <returns>The index schedule view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TrainId,StationId,ArrivalTime,DepartureTime")] ScheduleModel scheduleModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scheduleModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StationId = new SelectList(db.StationModels, "Id", "StationName", scheduleModel.StationId);
            ViewBag.TrainId = new SelectList(db.TrainsModels, "Id", "TrainName", scheduleModel.TrainId);
            return View(scheduleModel);
        }

        /// <summary>
        /// Checks if it is possible to delete schedule from database based on ID.
        /// </summary>
        /// <param name="id">ID corresponds to PK in database.</param>
        /// <returns>The delete schedule view with a list of datavalues that have ID as PK</returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleModel scheduleModel = db.ScheduleModels.Find(id);
            if (scheduleModel == null)
            {
                return HttpNotFound();
            }
            return View(scheduleModel);
        }

        /// <summary>
        /// Delete schedule data from database that has ID as PK
        /// </summary>
        /// <param name="id">ID corresponds to PK in database</param>
        /// <returns>The index schedule view</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ScheduleModel scheduleModel = db.ScheduleModels.Find(id);
            db.ScheduleModels.Remove(scheduleModel);
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
