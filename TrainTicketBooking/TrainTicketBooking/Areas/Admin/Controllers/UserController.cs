using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TrainTicketBooking.Areas.Admin.Models;
using TrainTicketBooking.Data;
using TrainTicketBooking.Models;

namespace TrainTicketBooking.Areas.Admin.Controllers
{
    /// <summary>
    /// UserController controls http and db requests related to user admin.
    /// </summary>
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private ApplicationUserManager _userManager;
        // create a database context.
        private ApplicationDbContext db = new ApplicationDbContext();

        public UserController()
        {

        }

        /// <summary>
        /// Constructor with param. creates the object usermanager.
        /// </summary>
        /// <param name="userManager"></param>
        public UserController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        /// <summary>
        /// setter and getter for userManager.
        /// </summary>
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        /// <summary>
        /// ActionResult returns values of user back to view. 
        /// </summary>
        /// <returns>Returns db.Users as a list to view.</returns>
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        /// <summary>
        /// Checks if it is possible to view details on user from database based on ID.
        /// </summary>
        /// <param name="id">ID corresponds to PK in database.</param>
        /// <returns>The details applicationUser view with datavalues that have ID as PK</returns>
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        /// <summary>
        /// Opens a new create user view
        /// </summary>
        /// <returns>Return a create user view.</returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates a new admin user.
        /// 
        /// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        /// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /// </summary>
        /// <param name="model">A model based on the requirements in CreateUserVM</param>
        /// <returns>To user view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateUserVM model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { FirstName = model.FirstName, LastName = model.LastName, UserName = model.Email, Email = model.Email, Gender = model.Gender, BirthDate = model.BirthDate };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "User");
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }


        /// <summary>
        /// Checks if it is possible to edit user from database based on ID.
        /// </summary>
        /// <param name="id">ID corresponds to PK in database.</param>
        /// <returns>The edit user view with a list of datavalues that have ID as PK</returns>
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        /// <summary>
        /// Edit user data from database based on the list routesModel.
        /// 
        /// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        /// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /// </summary>
        /// <param name="applicationUser">List of database values.</param>
        /// <returns>The index user view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Gender,BirthDate,Address,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(applicationUser).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {

                }
            }
            return View(applicationUser);
        }

        /// <summary>
        /// Checks if it is possible to delete user from database based on ID.
        /// </summary>
        /// <param name="id">ID corresponds to PK in database.</param>
        /// <returns>The delete user view with a list of datavalues that have ID as PK</returns>
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        /// <summary>
        /// Delete user data from database that has ID as PK
        /// </summary>
        /// <param name="id">ID corresponds to PK in database</param>
        /// <returns>The index user view</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ApplicationUser applicationUser = db.Users.Find(id);
            db.Users.Remove(applicationUser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Release unmanaged database resources 
        /// </summary>
        /// <param name="disposing">Bool value true or false</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Set errors for every IdentityResult based on result. 
        /// </summary>
        /// <param name="result">state of operation.</param>
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}
