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
    [Authorize(Roles = "Admin")]
    public class ApplicationRolesController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;
        public ApplicationRolesController()
        {

        }
        public ApplicationRolesController(ApplicationUserManager userManager, ApplicationRoleManager roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }


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

        // GET: ApplicationRoles
        public ActionResult Index()
        {
            return View(RoleManager.Roles.ToList());
        }

        // GET: ApplicationRoles/Details/5
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
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApplicationRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        //GET: ApplicationRoles/Edit/5
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

        // POST: ApplicationRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // POST: ApplicationRoles/Delete/5
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
