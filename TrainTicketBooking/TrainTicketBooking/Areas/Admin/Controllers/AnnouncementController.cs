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
    /// announcementController controls http and db requests related to announcement.
    /// </summary>
    [Authorize(Roles ="Admin")]
    public class AnnouncementController : Controller
    {
        //create a database context.
        private ApplicationDbContext db = new ApplicationDbContext();

        /// <summary>
        /// ActionResult returns values of announcement back to view. 
        /// </summary>
        /// <returns>Returns db.announcementModels as a list to view.</returns>
        public ActionResult Index()
        {
            return View(db.AnnouncementModels.ToList());
        }

        /// <summary>
        /// Checks if it is possible to view details on announcement from database based on ID.
        /// </summary>
        /// <param name="id">ID corresponds to PK in database.</param>
        /// <returns>The details announcementModel view with datavalues that have ID as PK</returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnnouncementModel announcementModel = db.AnnouncementModels.Find(id);
            if (announcementModel == null)
            {
                return HttpNotFound();
            }
            return View(announcementModel);
        }

        /// <summary>
        /// Opens a new create announcement view
        /// </summary>
        /// <returns>Return a create announcement view.</returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates announcement data and sends to database.
        /// 
        /// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        /// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /// </summary>
        /// <param name="announcementModel">List of database values.</param>
        /// <returns>The index announcement view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Description,CreatedDate,ValidFrom,ValidTo")] AnnouncementModel announcementModel)
        {
            if (ModelState.IsValid)
            {
                db.AnnouncementModels.Add(announcementModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(announcementModel);
        }

        /// <summary>
        /// Checks if it is possible to edit announcement from database based on ID.
        /// </summary>
        /// <param name="id">ID corresponds to PK in database.</param>
        /// <returns>The edit announcement view with a list of datavalues that have ID as PK</returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnnouncementModel announcementModel = db.AnnouncementModels.Find(id);
            if (announcementModel == null)
            {
                return HttpNotFound();
            }
            return View(announcementModel);
        }

        /// <summary>
        /// Edit announcement data from database based on the list announcementModel.
        /// 
        /// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        /// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /// </summary>
        /// <param name="announcementModel">List of database values.</param>
        /// <returns>The index announcement view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,CreatedDate,ValidFrom,ValidTo")] AnnouncementModel announcementModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(announcementModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(announcementModel);
        }

        /// <summary>
        /// Checks if it is possible to delete announcement from database based on ID.
        /// </summary>
        /// <param name="id">ID corresponds to PK in database.</param>
        /// <returns>The delete announcement view with a list of datavalues that have ID as PK</returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnnouncementModel announcementModel = db.AnnouncementModels.Find(id);
            if (announcementModel == null)
            {
                return HttpNotFound();
            }
            return View(announcementModel);
        }

        /// <summary>
        /// Delete announcement data from database that has ID as PK
        /// </summary>
        /// <param name="id">ID corresponds to PK in database</param>
        /// <returns>The index announcement view</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AnnouncementModel announcementModel = db.AnnouncementModels.Find(id);
            db.AnnouncementModels.Remove(announcementModel);
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
