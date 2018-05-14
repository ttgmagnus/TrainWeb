using System.Web.Mvc;

namespace TrainTicketBooking.Areas.Admin
{
    /// <summary>
    /// Class is for admin registration
    /// </summary>
    public class AdminAreaRegistration : AreaRegistration 
    {
        /// <summary>
        /// Getter for the place where files under admin are stored.
        /// </summary>
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        /// <summary>
        /// Sets the area route to admin, and the index page
        /// </summary>
        /// <param name="context">The context of the area</param>
        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}