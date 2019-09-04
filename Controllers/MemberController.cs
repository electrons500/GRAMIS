using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GRAMIS.Models.Data.GramisContext;
using GRAMIS.Models.Service;
using GRAMIS.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GRAMIS.Controllers
{
    public class MemberController : Controller
    {
        private MemberService _memberService;
       
        public MemberController(MemberService memberService)
        {
            _memberService = memberService;
           
        }
        // GET: Member
        public ActionResult Index(string searchstring ,int? pagenumber =1)
        {

            //ViewData["txtsearch"] = searchstring;
            if (searchstring != null)
            {
                var model = _memberService.SearchMembers(searchstring);
                pagenumber = 1;
                return View(model);
            }
            else
            {
                var model = _memberService.GetMembers();
                return View(model);
            }


            //var qry = _context.Member.AsNoTracking().OrderBy(p => p.Fullname);
            //int pageSize = 3;
            //var model = await PaginatedList<Member>.CreateAsync(qry,pagenumber ?? 1,pageSize);
            //return View(model);

        }

        // GET: Member/Details/5
        public ActionResult MemberDetails(int id)
        {
            var model = _memberService.GetMemberDetails(id);
            return View(model);
        }

        // GET: Member/Create
        public ActionResult AddMember()
        {
            var model = _memberService.Create();
            return View(model);
        }

        // POST: Member/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMember(MemberViewModel model, string id)
        {

            try
            {
                // TODO: Add insert logic here
                bool result = _memberService.AddMember(model);
                if (result)
                {
                    return RedirectToAction("AddDocument", "DocumentCollection", new { id });
                }
                throw new Exception();
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Sorry,New member submission failed");

                return View();
            }
        }

        // GET: Member/Edit/5
        public ActionResult EditMember(int id)
        {
            var model = _memberService.GetMemberDetails(id);
            return View(model);
        }

        // POST: Member/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditMember(int id, MemberViewModel model)
        {
            try
            {
                // TODO: Add insert logic here
                bool result = _memberService.UpdateMember(model);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                throw new Exception();
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Sorry,submission of Changes failed");
                return View();
            }
        }

        // GET: Member/Delete/5
        public ActionResult RemoveMember(int id)
        {
            var model = _memberService.GetMemberDetails(id);
            return View(model);
        }

        // POST: Member/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveMember(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                bool result = _memberService.DeleteMember(id);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                throw new Exception();
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Sorry,submission of Changes failed");
                return View();
            }
        }
    }
}