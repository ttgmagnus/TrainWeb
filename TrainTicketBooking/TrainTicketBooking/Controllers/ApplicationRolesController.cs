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
using TrainTicketBooking.Data;
using TrainTicketBooking.Models;
using static TrainTicketBooking.ApplicationSignInManager;

namespace TrainTicketBooking.Controllers
{
    /// <summary>
    /// Controller for hhtp and db action for the application role admin.
    /// </summary>
    [Authorize(Roles = "Admin")]
    public class ApplicationRolesController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;

        public ApplicationRolesController()
        {

        }

        /// <summary>
        /// sets the UserManager and RoleManager values.
        /// </summary>
        /// <param name="userManager">Name for the userManager</param>
        /// <param name="roleManager">Name for the roleManager</param>
        public ApplicationRolesController(ApplicationUserManager userManager, ApplicationRoleManager roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }

        /// <summary>
        /// Properties for member _roleManager.
        /// </summary>
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }

        /// <summary>
        /// Properties for member _userManager.
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
        /// Returnes the applicationRoles to index view.
        /// </summary>
        /// <returns>index view.</returns>
        public ActionResult Index()
        {
            return View(RoleManager.Roles.ToList());
        }
        
        /// <summary>
        /// Check if details of applicatonRoles can be found based on Id.
        /// </summary>
        /// <param name="id">Id corresponds to PK in database.</param>
        /// <returns>details of applicationRoles</returns>
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationRole applicationRole = await RoleManager.FindByIdAsync(id);
            if (applicationRole == null)
            {
                return HttpNotFound();
            }
            return View(applicationRole);
        }

        // GET: ApplicationRoles/Create
        /// <summary>
        /// Return the create view for applicationRoles.
        /// </summary>
        /// <returns>Create View.</returns>
        public ActionResult Create()
        {
            return View();
        }
        
        /// <summary>
        /// Creates a new ApplicationRoles.
        /// 
        /// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        /// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /// </summary>
        /// <param name="applicationRoleVm">Model based on the ApplicationRoleVM</param>
        /// <returns>View.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Name")] ApplicationRoleVM applicationRoleVm)
        {

            if (ModelState.IsValid)
            {
                ApplicationRole applicationRole = new ApplicationRole { Name = applicationRoleVm.Name };
                var roleResult = await RoleManager.CreateAsync(applicationRole);

                if (!roleResult.Succeeded)
                {
                    ModelState.AddModelError("", roleResult.Errors.ToString());
                    return View();
                }
                return RedirectToAction("Index");
            }

            return View();
        }
        
        /// <summary>
        /// Check if it databaseobject is found based on Id.
        /// </summary>
        /// <param name="id">Id corresponds to PK in database.</param>
        /// <returns></returns>
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationRole applicationRole = await RoleManager.FindByIdAsync(id);
            if (applicationRole == null)
            {
                return HttpNotFound();
            }
            ApplicationRoleVM applicationRoleVM = new ApplicationRoleVM
            {
                Id = applicationRole.Id,
                Name = applicationRole.Name
            };
            return View(applicationRoleVM);
        }
        
        /// <summary>
        /// Edit ApplicationRole.
        /// 
        /// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        /// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// </summary>
        /// <param name="applicationRoleVM">Model that desides what values to use.</param>
        /// <returns>applicationRoleVM to view.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] ApplicationRoleVM applicationRoleVM)
        {
            if (ModelState.IsValid)
            {
                ApplicationRole applicationRole = await RoleManager.FindByIdAsync(applicationRoleVM.Id);
                string originalName = applicationRole.Name;
                if (originalName == "Admin" && applicationRoleVM.Name != "Admin")
                {
                    ModelState.AddModelError("", "You Cannot Change the Name of Admin Role");
                    return View(applicationRoleVM);
                }
                if (originalName != "Admin" && applicationRoleVM.Name == "Admin")
                {
                    ModelState.AddModelError("", "You Cannot Change the Name of Role to Admin");
                    return View(applicationRoleVM);
                }
                applicationRole.Name = applicationRoleVM.Name;
                await RoleManager.UpdateAsync(applicationRole);
                return RedirectToAction("Index");
            }
            return View(applicationRoleVM);
        }

        // GET: ApplicationRoles/Delete/5
        /// <summary>
        /// Check if database object is found base on Id.
        /// </summary>
        /// <param name="id">Id corresponds to Pk in database.</param>
        /// <returns></returns>
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationRole applicationRole = await RoleManager.FindByIdAsync(id);
            if (applicationRole == null)
            {
                return HttpNotFound();
            }
            return View(applicationRole);
        }
        
        /// <summary>
        /// Confirm and validate delete of ApplicationRole based on id.
        /// </summary>
        /// <param name="id">Id corresponds to pk in database.</param>
        /// <returns>Index view.</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            ApplicationRole applicationRole = await RoleManager.FindByIdAsync(id);
            if (applicationRole.Name == "Admin")
            {
                ModelState.AddModelError("", "You cannot delete the Admin Role");
                return View(applicationRole);
            }
            await RoleManager.DeleteAsync(applicationRole);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Dispose unmanaged RoleManagers.
        /// </summary>
        /// <param name="disposing">Bool value true or false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                RoleManager.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
