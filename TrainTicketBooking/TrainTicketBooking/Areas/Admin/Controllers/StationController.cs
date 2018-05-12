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
    /// stationController controls http and db requests related to train station.
    /// </summary>
    [Authorize(Roles = "Admin")]
    public class StationController : Controller
    {
        //create a database context.
        private ApplicationDbContext db = new ApplicationDbContext();

        /// <summary>
        /// ActionResult returns values of station back to view. 
        /// </summary>
        /// <returns>Returns db.stationModels as a list to view.</returns>
        public ActionResult Index()
        {
            return View(db.StationModels.ToList());
        }

        /// <summary>
        /// Checks if it is possible to view details on station from database based on ID.
        /// </summary>
        /// <param name="id">ID corresponds to PK in database.</param>
        /// <returns>The details stationModel view with datavalues that have ID as PK</returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StationModel stationModel = db.StationModels.Find(id);
            if (stationModel == null)
            {
                return HttpNotFound();
            }
            return View(stationModel);
        }

        /// <summary>
        /// Opens a new create station view
        /// </summary>
        /// <returns>Return a create station view.</returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates station data and sends to database.
        /// 
        /// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        /// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /// </summary>
        /// <param name="stationModel">List of database values.</param>
        /// <returns>The index station view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StationName,StationCode")] StationModel stationModel)
        {
            if (ModelState.IsValid)
            {
                db.StationModels.Add(stationModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stationModel);
        }

        /// <summary>
        /// Checks if it is possible to edit station from database based on ID.
        /// </summary>
        /// <param name="id">ID corresponds to PK in database.</param>
        /// <returns>The edit station view with a list of datavalues that have ID as PK</returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StationModel stationModel = db.StationModels.Find(id);
            if (stationModel == null)
            {
                return HttpNotFound();
            }
            return View(stationModel);
        }

        /// <summary>
        /// Edit station data from database based on the list stationModel.
        /// 
        /// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        /// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /// </summary>
        /// <param name="stationModel">List of database values.</param>
        /// <returns>The index station view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StationName,StationCode")] StationModel stationModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stationModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stationModel);
        }

        /// <summary>
        /// Checks if it is possible to delete station from database based on ID.
        /// </summary>
        /// <param name="id">ID corresponds to PK in database.</param>
        /// <returns>The delete station view with a list of datavalues that have ID as PK</returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StationModel stationModel = db.StationModels.Find(id);
            if (stationModel == null)
            {
                return HttpNotFound();
            }
            return View(stationModel);
        }

        /// <summary>
        /// Delete station data from database that has ID as PK
        /// </summary>
        /// <param name="id">ID corresponds to PK in database</param>
        /// <returns>The index station view</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StationModel stationModel = db.StationModels.Find(id);
            db.StationModels.Remove(stationModel);
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
