using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrainTicketBooking.Areas.Admin.Controllers
{
    /// <summary>
    /// DashboardController contains a method for dealing with http requests
    /// </summary>
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        /// <summary>
        /// ActionResult Index return the admin dashboard as a view. 
        /// </summary>
        /// <returns>View based on context</returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}