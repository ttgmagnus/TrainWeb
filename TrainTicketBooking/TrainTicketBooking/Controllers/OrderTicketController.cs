using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainTicketBooking.Data;
using TrainTicketBooking.Models;

namespace TrainTicketBooking.Controllers
{
    /// <summary>
    /// Controller for orderering tickets
    /// </summary>
    [Authorize]
    public class OrderTicketController : Controller
    {
        // makes a new database context.
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: OrderTicket
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Creates and places lists into the viewbag
        /// </summary>
        /// <returns>View based on ActionResult</returns>
        public ActionResult OrderTicket()
        {
            ViewBag.TrainId = new SelectList(db.TrainsModels, "Id", "TrainName");
            ViewBag.StationFrom = new SelectList(db.StationModels, "Id", "StationName");
            ViewBag.StationTo = new SelectList(db.StationModels, "Id", "StationName");
            return View();
        }
        /// <summary>
        /// Takes the input from the view the user input and makes a ticket and sends that ticket to the database 
        /// before returning a message if successful and the ticket information to the view.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult OrderTicket(OrderTicketVM model)
        {
            ViewBag.TrainId = new SelectList(db.TrainsModels, "Id", "TrainName");
            ViewBag.StationFrom = new SelectList(db.StationModels, "Id", "StationName");
            ViewBag.StationTo = new SelectList(db.StationModels, "Id", "StationName");

            //check if the values that the user want to input into the database have the same type as the database.
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