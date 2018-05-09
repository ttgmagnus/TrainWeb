using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainTicketBooking.Data;
using TrainTicketBooking.Models;

namespace TrainTicketBooking.Controllers
{
    [Authorize]
    public class OrderTicketController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: OrderTicket
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult OrderTicket()
        {
            ViewBag.TrainId = new SelectList(db.TrainsModels, "Id", "TrainName");
            ViewBag.StationFrom = new SelectList(db.StationModels, "Id", "StationName");
            ViewBag.StationTo = new SelectList(db.StationModels, "Id", "StationName");
            return View();
        }
        [HttpPost]
        public ActionResult OrderTicket(OrderTicketVM model)
        {
            ViewBag.TrainId = new SelectList(db.TrainsModels, "Id", "TrainName");
            ViewBag.StationFrom = new SelectList(db.StationModels, "Id", "StationName");
            ViewBag.StationTo = new SelectList(db.StationModels, "Id", "StationName");
            if (ModelState.IsValid)
            {
                var ticket = new TicketModel { TrainId = model.TrainId, CustomerID = User.Identity.Name, OrderDate = model.OrderDate, StationFrom = model.StationFrom, StationTo = model.StationTo, TravelDate = model.TravelDate };
                db.TicketModels.Add(ticket);
                db.SaveChanges();
                ViewBag.Success = "Your Ticket Successfully Order Thank you...!!!";
                return View();
            }
           
            return View(model);
        }
    }
}