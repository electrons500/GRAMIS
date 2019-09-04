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
    public class DocumentCategoriesController : Controller
    {
        private DocumentCategoryService _documentCategoryService;
        public DocumentCategoriesController(DocumentCategoryService documentCategoryService)
        {
            _documentCategoryService = documentCategoryService;
        }
        // GET: DocumentCategories
        public ActionResult Index()
        {
            var model = _documentCategoryService.GetDocumentCategories();

            return View(model);
        }

        // GET: DocumentCategories/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DocumentCategories/Create
        public ActionResult AddDocumentCategory()
        {
            return View();
        }

        // POST: DocumentCategories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDocumentCategory(DocumentCategoriesViewModel model)
        {
            try
            {
                // TODO: Add insert logic here
                bool result = _documentCategoryService.AddDocumentCategory(model);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                throw new Exception();
            }
            catch
            {
                return View();
            }
        }

        // GET: DocumentCategories/Edit/5
        public ActionResult EditDocumentCategories(int id)
        {
            var model = _documentCategoryService.GetDocumentCategoriesDetails(id);
            return View(model);
        }

        // POST: DocumentCategories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDocumentCategories(int id, DocumentCategoriesViewModel model)
        {
            try
            {
                // TODO: Add insert logic here
                bool result = _documentCategoryService.UpdateDocumentCategories(model);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                throw new Exception();
            }
            catch
            {
                return View();
            }
        }

        // GET: DocumentCategories/Delete/5
        public ActionResult DeleteDocumentCategories(int id)
        {
            var model = _documentCategoryService.GetDocumentCategoriesDetails(id);
            return View(model);
        }

        // POST: DocumentCategories/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDocumentCategories(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                bool result = _documentCategoryService.DeleteDocumentCategories(id);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                throw new Exception();
            }
            catch
            {
                return View();
            }
        }
    }
}