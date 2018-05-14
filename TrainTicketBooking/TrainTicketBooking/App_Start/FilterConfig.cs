using System.Web;
using System.Web.Mvc;

namespace TrainTicketBooking
{
    /// <summary>
    /// This class use the GlobalFilterCollection class from System.Web.Mvc to make a filter
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// This method makes a filter called RegisterGlobalFilters and adds a 
        /// new HandleErrorAttribute that handles errors thrown by an action method
        /// </summary>
        /// <param name="filters">Input filters</param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
