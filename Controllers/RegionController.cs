using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GRAMIS.Models.Service;
using GRAMIS.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GRAMIS.Controllers
{
    public class RegionController : Controller
    {
        private RegionService _regionService;
        public RegionController(RegionService regionService)
        {
            _regionService = regionService;
        }
        // GET: Region
        public ActionResult Index()
        {
            var model = _regionService.GetRegions();
            return View(model);
        }

        // GET: Region/Details/5
        public ActionResult Details(int id)
        {
            var model = _regionService.GetRegionDetails(id);
            return View(model);
        }

        // GET: Region/Create
        public ActionResult AddRegion()
        {
            return View();
        }

        // POST: Region/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddRegion(RegionViewModel model)
        {
            try
            {
                // TODO: Add insert logic here
                bool result = _regionService.AddNewRegion(model);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }

                throw new Exception();
               
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Sorry, New Region Submission failed!");
                return View();
            }
        }

        // GET: Region/Edit/5
        public ActionResult EditRegion(int id)
        {
            var model = _regionService.GetRegionDetails(id);
            return View(model);
        }

        // POST: Region/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditRegion(int id,RegionViewModel model)
        {
            try
            {
                // TODO: Add insert logic here
                bool result = _regionService.UpdateRegion(model);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }

                throw new Exception();

            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Sorry, Submission of Changes failed!");
                return View();
            }
        }

        // GET: Region/Delete/5
        public ActionResult DeleteRegion(int id)
        {
            var model = _regionService.GetRegionDetails(id);
            return View(model);
        }

        // POST: Region/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRegion(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                bool result = _regionService.DeleteRegion(id);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }

                throw new Exception();

            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Sorry,failed to Delete!");
                return View();
            }
        }
    }
}