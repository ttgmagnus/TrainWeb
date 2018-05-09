namespace TrainTicketBooking.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TrainTicketBooking.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "TrainTicketBooking.Data.ApplicationDbContext";
        }

        protected override void Seed(Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(context));

            const string name = "admin@test.com";
            const string password = "Test2go!";
            const string roleName = "Admin";
            const string fistName = "Super";
            const string lastname = "Admin";



            var role = roleManager.FindByName(roleName);
            //Create Role Admin if it does not exist
            if (role == null)
            {
                role = new ApplicationRole(roleName);
                var roleresult = roleManager.Create(role);
            }

            //Create User=Admin
            var user = userManager.FindByName(name);
            if (user == null)
            {
                user = new ApplicationUser { Email = name, UserName = name, FirstName = fistName, LastName = lastname };
                var result = userManager.Create(user, password);
                result = userManager.SetLockoutEnabled(user.Id, false);
            }
            //Add To Role if not exsit
            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                var result = userManager.AddToRole(user.Id, role.Name);
            }
        }
    }
}
