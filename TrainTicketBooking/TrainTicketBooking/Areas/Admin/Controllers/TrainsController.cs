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
    public class TrainsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Trains
        public ActionResult Index()
        {
            var trainsModels = db.TrainsModels.Include(t => t.Routes).Include(t => t.Stations1).Include(t => t.Stations2);
            return View(trainsModels.ToList());
        }

        // GET: Admin/Trains/Details/5
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

        // GET: Admin/Trains/Create
        public ActionResult Create()
        {
            ViewBag.RouteId = new SelectList(db.RoutesModels, "Id", "RouteName");
            ViewBag.StartStation = new SelectList(db.StationModels, "Id", "StationName");
            ViewBag.EndStation = new SelectList(db.StationModels, "Id", "StationName");
            return View();
        }

        // POST: Admin/Trains/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Admin/Trains/Edit/5
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

        // POST: Admin/Trains/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Admin/Trains/Delete/5
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

        // POST: Admin/Trains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrainsModel trainsModel = db.TrainsModels.Find(id);
            db.TrainsModels.Remove(trainsModel);
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
