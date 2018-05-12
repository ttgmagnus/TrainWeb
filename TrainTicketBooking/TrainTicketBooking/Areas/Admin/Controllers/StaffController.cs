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
    /// staffController controls http and db requests related to train staff.
    /// </summary>
    [Authorize(Roles = "Admin")]
    public class StaffController : Controller
    {
        //create a database context.
        private ApplicationDbContext db = new ApplicationDbContext();

        /// <summary>
        /// ActionResult returns values of staff back to view. 
        /// </summary>
        /// <returns>Returns db.staffModels as a list to view.</returns>
        public ActionResult Index()
        {
            return View(db.StaffModels.ToList());
        }

        /// <summary>
        /// Checks if it is possible to view details on staff from database based on ID.
        /// </summary>
        /// <param name="id">ID corresponds to PK in database.</param>
        /// <returns>The details staffModel view with datavalues that have ID as PK</returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffModel staffModel = db.StaffModels.Find(id);
            if (staffModel == null)
            {
                return HttpNotFound();
            }
            return View(staffModel);
        }

        /// <summary>
        /// Opens a new create staff view
        /// </summary>
        /// <returns>Return a create staff view.</returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates staff data and sends to database.
        /// 
        /// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        /// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /// </summary>
        /// <param name="staffModel">List of database values.</param>
        /// <returns>The index staff view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Email,Address,JoinDate,BirthDate,Description")] StaffModel staffModel)
        {
            if (ModelState.IsValid)
            {
                db.StaffModels.Add(staffModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(staffModel);
        }

        /// <summary>
        /// Checks if it is possible to edit staff from database based on ID.
        /// </summary>
        /// <param name="id">ID corresponds to PK in database.</param>
        /// <returns>The edit staff view with a list of datavalues that have ID as PK</returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffModel staffModel = db.StaffModels.Find(id);
            if (staffModel == null)
            {
                return HttpNotFound();
            }
            return View(staffModel);
        }

        /// <summary>
        /// Edit staff data from database based on the list staffModel.
        /// 
        /// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        /// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /// </summary>
        /// <param name="staffModel">List of database values.</param>
        /// <returns>The index staff view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,Address,JoinDate,BirthDate,Description")] StaffModel staffModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(staffModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(staffModel);
        }

        /// <summary>
        /// Checks if it is possible to delete staff from database based on ID.
        /// </summary>
        /// <param name="id">ID corresponds to PK in database.</param>
        /// <returns>The delete staff view with a list of datavalues that have ID as PK</returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffModel staffModel = db.StaffModels.Find(id);
            if (staffModel == null)
            {
                return HttpNotFound();
            }
            return View(staffModel);
        }

        /// <summary>
        /// Delete staff data from database that has ID as PK
        /// </summary>
        /// <param name="id">ID corresponds to PK in database</param>
        /// <returns>The index staff view</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StaffModel staffModel = db.StaffModels.Find(id);
            db.StaffModels.Remove(staffModel);
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
