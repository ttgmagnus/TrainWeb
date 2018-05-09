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
    public class StationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Station
        public ActionResult Index()
        {
            return View(db.StationModels.ToList());
        }

        // GET: Admin/Station/Details/5
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

        // GET: Admin/Station/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Station/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Admin/Station/Edit/5
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

        // POST: Admin/Station/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Admin/Station/Delete/5
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

        // POST: Admin/Station/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StationModel stationModel = db.StationModels.Find(id);
            db.StationModels.Remove(stationModel);
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
