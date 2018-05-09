using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainTicketBooking.Data;

namespace TrainTicketBooking.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext dbContext = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Announcements()
        {
            return View(dbContext.AnnouncementModels.ToList());
        }
        public ActionResult Trains()
        {
            ViewBag.Message = "Your application description page.";
            var trainsModels = dbContext.TrainsModels.Include(t => t.Routes).Include(t => t.Stations1).Include(t => t.Stations2);
            return View(trainsModels);
        }
        public ActionResult Schedule()
        {
            ViewBag.Message = "Your application description page.";
            var scheduleModels = dbContext.ScheduleModels.Include(s => s.Stations).Include(s => s.Trains);
            return View(scheduleModels.ToList());
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}