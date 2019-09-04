using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GRAMIS.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GRAMIS.Controllers
{
    public class RolesController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        // GET: Roles
        public ActionResult Index()
        {
            var Roles = _roleManager.Roles.ToList();
            List<RoleViewModel> model = Roles.Select(r => new RoleViewModel
            {
                RoleId = r.Id,
                RoleName = r.Name
            }).ToList();

            return View(model);
        }

        // GET: Roles/Details/5
        public ActionResult Details(string id)
        {
            var Roles = _roleManager.Roles.Where(x => x.Id == id).First();
            RoleViewModel model = new RoleViewModel
            {
                RoleId = Roles.Id,
                RoleName = Roles.Name
            };

            return View(model);
        }

        // GET: Roles/Create
        public ActionResult Addrole()
        {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Addrole(RoleViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(model.RoleName));
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }


                }
                return View(model);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Please an Error has occured!");
                throw;
            }
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(string id)
        {
            var Roles = _roleManager.Roles.Where(x => x.Id == id).First();
            RoleViewModel model = new RoleViewModel
            {
                RoleId = Roles.Id,
                RoleName = Roles.Name
            };

            return View(model);
        }

        // POST: Roles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(string id, RoleViewModel model)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(id);
                if (role != null)
                {
                    role.Id = model.RoleId;
                    role.Name = model.RoleName;

                    var result = await _roleManager.UpdateAsync(role);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                }

                return null;

            }
            catch
            {
                return View();
            }
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(string id)
        {
            var Roles = _roleManager.Roles.Where(x => x.Id == id).First();
            RoleViewModel model = new RoleViewModel
            {
                RoleId = Roles.Id,
                RoleName = Roles.Name
            };

            return View(model);
        }

        // POST: Roles/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(string id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var role = await _roleManager.FindByIdAsync(id);
                if (role != null)
                {
                    var result = await _roleManager.DeleteAsync(role);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}