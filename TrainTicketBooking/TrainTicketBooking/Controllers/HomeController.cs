using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainTicketBooking.Data;

namespace TrainTicketBooking.Controllers
{
    /// <summary>
    /// The controller for home. Directs what pages to show on action.
    /// </summary>
    public class HomeController : Controller
    {
        // Creates a db context.
        private ApplicationDbContext dbContext = new ApplicationDbContext();

        /// <summary>
        /// Returns index view for home as a result from an action.
        /// </summary>
        /// <returns>index view</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Returns about view for home as a result from an action.
        /// </summary>
        /// <returns>about view</returns>
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        /// <summary>
        /// Returns announcments view for home as a result from an action.
        /// The view returned is a result of database onjects returned as a list.
        /// </summary>
        /// <returns>announcements view</returns>
        public ActionResult Announcements()
        {
            return View(dbContext.AnnouncementModels.ToList());
        }

        /// <summary>
        /// Returns trains view for home as a result from an action.
        /// The view returned is a result of database onjects returned as a list.
        /// </summary>
        /// <returns>returns trains view</returns>
        public ActionResult Trains()
        {
            ViewBag.Message = "Your application description page.";
            var trainsModels = dbContext.TrainsModels.Include(t => t.Routes).Include(t => t.Stations1).Include(t => t.Stations2);
            return View(trainsModels);
        }

        /// <summary>
        /// Returns schedule view for home as a result from an action.
        /// The view returned is a result of database onjects returned as a list.
        /// </summary>
        /// <returns>returns schedule view</returns>
        public ActionResult Schedule()
        {
            ViewBag.Message = "Your application description page.";
            var scheduleModels = dbContext.ScheduleModels.Include(s => s.Stations).Include(s => s.Trains);
            return View(scheduleModels.ToList());
        }

        /// <summary>
        /// Returns contact view as a result from an action.
        /// </summary>
        /// <returns>contact view.</returns>
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}