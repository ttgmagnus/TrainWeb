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
    /// TrainsController controls http and db requests related to trains.
    /// </summary>
    [Authorize(Roles = "Admin")]
    public class TrainsController : Controller
    {
        //create a database context.
        private ApplicationDbContext db = new ApplicationDbContext();

        /// <summary>
        /// ActionResult returns values of trains back to view. 
        /// </summary>
        /// <returns>Returns db.trainsModels as a list to view.</returns>
        public ActionResult Index()
        {
            var trainsModels = db.TrainsModels.Include(t => t.Routes).Include(t => t.Stations1).Include(t => t.Stations2);
            return View(trainsModels.ToList());
        }

        /// <summary>
        /// Checks if it is possible to view details on trains from database based on ID.
        /// </summary>
        /// <param name="id">ID corresponds to PK in database.</param>
        /// <returns>The details trainsModel view with datavalues that have ID as PK</returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainsModel trainsModel = db.TrainsModels.Find(id);
            if (trainsModel == null)
            {
                return HttpNotFound();
            }
           
            return View(trainsModel);
        }

        /// <summary>
        /// Opens a new create trains view
        /// </summary>
        /// <returns>Return a create trains view.</returns>
        public ActionResult Create()
        {
            ViewBag.RouteId = new SelectList(db.RoutesModels, "Id", "RouteName");
            ViewBag.StartStation = new SelectList(db.StationModels, "Id", "StationName");
            ViewBag.EndStation = new SelectList(db.StationModels, "Id", "StationName");
            return View();
        }

        /// <summary>
        /// Creates trains data and sends to database.
        /// 
        /// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        /// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /// </summary>
        /// <param name="trainsModel">List of database values.</param>
        /// <returns>The index trains view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TrainName,TrainType,Site,StartStation,EndStation,StartTime,EndTime,RouteId")] TrainsModel trainsModel)
        {
            if (ModelState.IsValid)
            {
                db.TrainsModels.Add(trainsModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RouteId = new SelectList(db.RoutesModels, "Id", "RouteName", trainsModel.RouteId);
            ViewBag.StartStation = new SelectList(db.StationModels, "Id", "StationName", trainsModel.StartStation);
            ViewBag.EndStation = new SelectList(db.StationModels, "Id", "StationName", trainsModel.EndStation);
            return View(trainsModel);
        }

        /// <summary>
        /// Checks if it is possible to edit trains from database based on ID.
        /// </summary>
        /// <param name="id">ID corresponds to PK in database.</param>
        /// <returns>The edit trains view with a list of datavalues that have ID as PK</returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainsModel trainsModel = db.TrainsModels.Find(id);
            if (trainsModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.RouteId = new SelectList(db.RoutesModels, "Id", "RouteName", trainsModel.RouteId);
            ViewBag.StartStation = new SelectList(db.StationModels, "Id", "StationName", trainsModel.StartStation);
            ViewBag.EndStation = new SelectList(db.StationModels, "Id", "StationName", trainsModel.EndStation);
            return View(trainsModel);
        }

        /// <summary>
        /// Edit trains data from database based on the list trainsModel.
        /// 
        /// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        /// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /// </summary>
        /// <param name="trainsModel">List of database values.</param>
        /// <returns>The index trains view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TrainName,TrainType,Site,StartStation,EndStation,StartTime,EndTime,RouteId")] TrainsModel trainsModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainsModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RouteId = new SelectList(db.RoutesModels, "Id", "RouteName", trainsModel.RouteId);
            ViewBag.StartStation = new SelectList(db.StationModels, "Id", "StationName", trainsModel.StartStation);
            ViewBag.EndStation = new SelectList(db.StationModels, "Id", "StationName", trainsModel.EndStation);
            return View(trainsModel);
        }

        /// <summary>
        /// Checks if it is possible to delete trains from database based on ID.
        /// </summary>
        /// <param name="id">ID corresponds to PK in database.</param>
        /// <returns>The delete trains view with a list of datavalues that have ID as PK</returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainsModel trainsModel = db.TrainsModels.Find(id);
            if (trainsModel == null)
            {
                return HttpNotFound();
            }
            return View(trainsModel);
        }

        /// <summary>
        /// Delete trains data from database that has ID as PK
        /// </summary>
        /// <param name="id">ID corresponds to PK in database</param>
        /// <returns>The index trains view</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrainsModel trainsModel = db.TrainsModels.Find(id);
            db.TrainsModels.Remove(trainsModel);
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
