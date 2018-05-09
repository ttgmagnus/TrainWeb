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
    public class RoutesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Routes
        public ActionResult Index()
        {
            return View(db.RoutesModels.ToList());
        }

        // GET: Admin/Routes/Details/5
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

        // GET: Admin/Routes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Routes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Admin/Routes/Edit/5
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

        // POST: Admin/Routes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Admin/Routes/Delete/5
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

        // POST: Admin/Routes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoutesModel routesModel = db.RoutesModels.Find(id);
            db.RoutesModels.Remove(routesModel);
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
