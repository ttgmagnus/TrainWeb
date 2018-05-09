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
    [Authorize(Roles ="Admin")]
    public class AnnouncementController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Announcement
        public ActionResult Index()
        {
            return View(db.AnnouncementModels.ToList());
        }

        // GET: Admin/Announcement/Details/5
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

        // GET: Admin/Announcement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Announcement/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Admin/Announcement/Edit/5
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

        // POST: Admin/Announcement/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Admin/Announcement/Delete/5
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

        // POST: Admin/Announcement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AnnouncementModel announcementModel = db.AnnouncementModels.Find(id);
            db.AnnouncementModels.Remove(announcementModel);
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
