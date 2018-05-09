using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TrainTicketBooking.Startup))]
namespace TrainTicketBooking
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
