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
    public class RankController : Controller
    {
        private RankService _rankService;
        public RankController(RankService rankService)
        {
            _rankService = rankService;
        }
        // GET: Rank
        public ActionResult Index()
        {
            var model = _rankService.GetRanks();

            return View(model);
        }

        // GET: Rank/Details/5
        public ActionResult Details(int id)
        {
            var model = _rankService.GetRankDetails(id);
            return View(model);
        }

        // GET: Rank/Create
        public ActionResult AddRank()
        {
            return View();
        }

        // POST: Rank/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddRank(RankViewModel model)
        {
            try
            {
                // TODO: Add insert logic here
                bool result = _rankService.AddNewRank(model);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }

                throw new Exception();
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Sorry New Rank Submission failed!");
                return View();
            }
        }

        // GET: Rank/Edit/5
        public ActionResult EditRank(int id)
        {
            var model = _rankService.GetRankDetails(id);

            return View(model);
        }

        // POST: Rank/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditRank(int id, RankViewModel model)
        {
            try
            {
                // TODO: Add insert logic here
                bool result = _rankService.UpdateRank(model);
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

        // GET: Rank/Delete/5
        public ActionResult DeleteRank(int id)
        {
            var model = _rankService.GetRankDetails(id);

            return View(model);
        }

        // POST: Rank/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRank(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                bool result = _rankService.DeleteRank(id);
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