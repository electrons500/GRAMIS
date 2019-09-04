using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using GRAMIS.Models.Data.GramisContext;
using GRAMIS.Models.Service;
using GRAMIS.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GRAMIS.Controllers
{
  
    public class DocumentCollectionController : Controller
    {
        private DocumentCollectionService _documentCollectionService;
        private GRAMISContext _Context;
      
        public IConfiguration _configuration { get; }
        public DocumentCollectionController(DocumentCollectionService documentCollectionService,GRAMISContext context,IConfiguration configuration)
        {
            _documentCollectionService = documentCollectionService;
            _Context = context;
            _configuration = configuration;
        }
        // GET: DocumentCollection
       
        public ActionResult Index(string id)
        {

            ViewBag.id = id;
            
            var model = _documentCollectionService.GetFiles(Convert.ToInt32(id)); 
            return View(model);
        }

        // GET: DocumentCollection/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DocumentCollection/Create
        public ActionResult AddDocument(string id)
        {
            var model = _documentCollectionService.Create();
            if (id != null)
            {
                ViewBag.id = id;
            }
            else
            {
                ViewBag.id = "0";
            }
           
            return View(model);
            
        }

        // POST: DocumentCollection/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDocument(DocumentCollectionViewModel model,string id)
        {

            // return RedirectToAction("Index","DocumentCollection", new {id});

            try
            {
                // TODO: Add insert logic here
                bool result = _documentCollectionService.AddPdf(model);
                if (result)
                {
                    return RedirectToAction("Index", "DocumentCollection", new {id});
                }
                throw new Exception();
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Sorry,Document Upload failed!");
                return View();
            }

        }

        // GET: DocumentCollection/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DocumentCollection/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
        // GET: DocumentCollection/Delete/5
        public ActionResult DeleteDocument(int id)
        {
            int[] x = new int[2];
            var model = _documentCollectionService.GetDocumentDetails(id);
            x[0] = model.MemberId;
            ViewBag.id = x[0];
            return View(model);
        }

        
        // POST: DocumentCollection/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDocument(int id, IFormCollection collection)
        {
            int[] x = new int[2];
            var model = _documentCollectionService.GetDocumentDetails(id);
            x[0] = model.MemberId;
           
           // return RedirectToAction("Index", "DocumentCollection", new {id = num});


            try
            {
                // TODO: Add insert logic here
                bool result = _documentCollectionService.DeleteDocument(id);
                if (result)
                {
                   // return RedirectToAction(nameof(Index));
                    return RedirectToAction("Index", "DocumentCollection", new { id = x[0]});
                }
                throw new Exception();
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Sorry,Document failed to delete!");
                return View();
            }
        }
        [HttpGet]
        public FileContentResult Download(int? id)
        {
            string connection = _configuration["ConnectionStrings:DefaultConnection"];
            SqlDataReader dr;
            byte[] fileData = null;
            string fileCategory = "";
            string filename = "";
            SqlConnection con = new SqlConnection(connection);
            var sql = "select MemberId,DocumentCategoryId,FileName,FileCategory,FileData from DocumentCollection where FileId= '" + id + "'";
            con.Open();
            var cmd = new SqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                fileData = (byte[])dr["FileData"];
                fileCategory = dr["FileCategory"].ToString();
                filename = dr["FileName"].ToString();

            }
            con.Close();

            return File(fileData, fileCategory, filename);
        }
    }
}