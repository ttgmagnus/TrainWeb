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
    public class CarriageController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Carriage
        public ActionResult Index()
        {
            var carriageModels = db.CarriageModels.Include(c => c.Tickets);
            return View(carriageModels.ToList());
        }

        // GET: Admin/Carriage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarriageModel carriageModel = db.CarriageModels.Find(id);
            if (carriageModel == null)
            {
                return HttpNotFound();
            }
            return View(carriageModel);
        }

        // GET: Admin/Carriage/Create
        public ActionResult Create()
        {
            ViewBag.TicketId = new SelectList(db.TicketModels, "Id", "Id");
            return View();
        }

        // POST: Admin/Carriage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TicketId,Name,Type,Weight,Height,Width,Length,Description")] CarriageModel carriageModel)
        {
            if (ModelState.IsValid)
            {
                db.CarriageModels.Add(carriageModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TicketId = new SelectList(db.TicketModels, "Id", "Id", carriageModel.TicketId);
            return View(carriageModel);
        }

        // GET: Admin/Carriage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarriageModel carriageModel = db.CarriageModels.Find(id);
            if (carriageModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.TicketId = new SelectList(db.TicketModels, "Id",  "Id", carriageModel.TicketId);
            return View(carriageModel);
        }

        // POST: Admin/Carriage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TicketId,Name,Type,Weight,Height,Width,Length,Description")] CarriageModel carriageModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carriageModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TicketId = new SelectList(db.TicketModels, "Id", "Id", carriageModel.TicketId);
            return View(carriageModel);
        }

        // GET: Admin/Carriage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarriageModel carriageModel = db.CarriageModels.Find(id);
            if (carriageModel == null)
            {
                return HttpNotFound();
            }
            return View(carriageModel);
        }

        // POST: Admin/Carriage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarriageModel carriageModel = db.CarriageModels.Find(id);
            db.CarriageModels.Remove(carriageModel);
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
