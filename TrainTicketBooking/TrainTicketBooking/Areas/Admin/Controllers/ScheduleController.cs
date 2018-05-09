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
    public class ScheduleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Schedule
        public ActionResult Index()
        {
            var scheduleModels = db.ScheduleModels.Include(s => s.Stations).Include(s => s.Trains);
            return View(scheduleModels.ToList());
        }

        // GET: Admin/Schedule/Details/5
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

        // GET: Admin/Schedule/Create
        public ActionResult Create()
        {
            ViewBag.StationId = new SelectList(db.StationModels, "Id", "StationName");
            ViewBag.TrainId = new SelectList(db.TrainsModels, "Id", "TrainName");
            return View();
        }

        // POST: Admin/Schedule/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Admin/Schedule/Edit/5
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

        // POST: Admin/Schedule/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Admin/Schedule/Delete/5
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

        // POST: Admin/Schedule/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ScheduleModel scheduleModel = db.ScheduleModels.Find(id);
            db.ScheduleModels.Remove(scheduleModel);
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
