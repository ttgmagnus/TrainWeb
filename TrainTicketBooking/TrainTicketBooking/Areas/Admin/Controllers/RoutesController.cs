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
    /// RoutesController controls http and db requests related to train routes.
    /// </summary>
    [Authorize(Roles = "Admin")]
    public class RoutesController : Controller
    {
        // create a database context.
        private ApplicationDbContext db = new ApplicationDbContext();

        /// <summary>
        /// ActionResult returns values of routes back to view. 
        /// </summary>
        /// <returns>Returns db.RoutesModels as a list to view.</returns>
        public ActionResult Index()
        {
            return View(db.RoutesModels.ToList());
        }

        /// <summary>
        /// Checks if it is possible to view details on routes from database based on ID.
        /// </summary>
        /// <param name="id">ID corresponds to PK in database.</param>
        /// <returns>The details routesModel view with datavalues that have ID as PK</returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoutesModel routesModel = db.RoutesModels.Find(id);
            if (routesModel == null)
            {
                return HttpNotFound();
            }
            return View(routesModel);
        }

        /// <summary>
        /// Opens a new create route view
        /// </summary>
        /// <returns>Return a create route view.</returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates routes data and sends to database.
        /// 
        /// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        /// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /// </summary>
        /// <param name="routesModel">List of database values.</param>
        /// <returns>The index route view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RouteName,RouteDescription")] RoutesModel routesModel)
        {
            if (ModelState.IsValid)
            {
                db.RoutesModels.Add(routesModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(routesModel);
        }
        
        /// <summary>
        /// Checks if it is possible to edit routes from database based on ID.
        /// </summary>
        /// <param name="id">ID corresponds to PK in database.</param>
        /// <returns>The edit routes view with a list of datavalues that have ID as PK</returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoutesModel routesModel = db.RoutesModels.Find(id);
            if (routesModel == null)
            {
                return HttpNotFound();
            }
            return View(routesModel);
        }

        /// <summary>
        /// Edit routes data from database based on the list routesModel.
        /// 
        /// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        /// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /// </summary>
        /// <param name="routesModel">List of database values.</param>
        /// <returns>The index route view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RouteName,RouteDescription")] RoutesModel routesModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(routesModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(routesModel);
        }
        
        /// <summary>
        /// Checks if it is possible to delete routes from database based on ID.
        /// </summary>
        /// <param name="id">ID corresponds to PK in database.</param>
        /// <returns>The delete routes view with a list of datavalues that have ID as PK</returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoutesModel routesModel = db.RoutesModels.Find(id);
            if (routesModel == null)
            {
                return HttpNotFound();
            }
            return View(routesModel);
        }
        
        /// <summary>
        /// Delete route data from database that has ID as PK
        /// </summary>
        /// <param name="id">ID corresponds to PK in database</param>
        /// <returns>The index route view</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoutesModel routesModel = db.RoutesModels.Find(id);
            db.RoutesModels.Remove(routesModel);
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
