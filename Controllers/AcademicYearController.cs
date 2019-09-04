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
    public class AcademicYearController : Controller
    {
        private AcademicYearService _academicYearServce;
        public AcademicYearController(AcademicYearService academicYearServce)
        {
            _academicYearServce = academicYearServce;   
        }
        // GET: AcademicYear
        public ActionResult Index()
        {
            var model = _academicYearServce.GetAcademicYear();
            return View(model);
        }

        // GET: AcademicYear/Details/5
        public ActionResult Details(int id)
        {
            var model = _academicYearServce.GetAcademicYearDetails(id);
            return View(model);
        }

        // GET: AcademicYear/Create
        public ActionResult Addacyear()
        {
            return View();
        }

        // POST: AcademicYear/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Addacyear(AcademicYearViewModel model)
        {
            try
            {
                // TODO: Add insert logic here
                bool result = _academicYearServce.AddAcademicYear(model);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }

                throw new Exception();
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Sorry New academic year Submission failed!");
                return View();
            }
        }

        // GET: AcademicYear/Edit/5
        public ActionResult EditAcyear(int id)
        {
            var model = _academicYearServce.GetAcademicYearDetails(id);
            return View(model);
        }

        // POST: AcademicYear/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAcyear(int id,AcademicYearViewModel model)
        {
            try
            {
                // TODO: Add insert logic here
                bool result = _academicYearServce.UpdateAcademicYear(model);
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

        // GET: AcademicYear/Delete/5
        public ActionResult DeleteAcyear(int id)
        {
            var model = _academicYearServce.GetAcademicYearDetails(id);
            return View(model);
        }

        // POST: AcademicYear/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAcyear(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                bool result = _academicYearServce.DeleteAcademicYear(id);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }

                throw new Exception();
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Sorry, failed to Delete!");
                return View();
            }
        }
    }
}