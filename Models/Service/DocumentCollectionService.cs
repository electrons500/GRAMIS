using GRAMIS.Models.Data.GramisContext;
using GRAMIS.Models.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GRAMIS.Models.Service
{
    public class DocumentCollectionService
    {
        private GRAMISContext _Context;
        private DocumentCategoryService _documentCategoryService;
        public DocumentCollectionService(GRAMISContext context,DocumentCategoryService documentCategoryService)
        {
            _Context = context;
            _documentCategoryService = documentCategoryService;
        }
        public List<DocumentCollectionViewModel> GetFiles(int mid)
        {
          
            try
            {
                List<DocumentCollection> Files = _Context.DocumentCollection.Where(x => x.MemberId == mid).Include(x => x.DocumentCategory).ToList();
                
                List<DocumentCollectionViewModel> model = Files.Select(x => new DocumentCollectionViewModel
                {
                   Id = x.FileId,
                   MemberId = x.MemberId,
                   DocumentCategoryId = x.DocumentCategoryId,
                   DocumentCategoryName = x.DocumentCategory.Name,
                   FileName = x.FileName,
                   FileCategory = x.FileCategory
                }).ToList();

                return model;
            }
            catch (Exception)
            {

                List<DocumentCollectionViewModel> emptymodel = new List<DocumentCollectionViewModel>();
                return emptymodel;
            }
        }


        public bool AddPdf(DocumentCollectionViewModel model)
        {
            DocumentCollection documentCollection = new DocumentCollection();
            if (model.filecollectionData != null)
            {
                byte[] filebyte;
                using (MemoryStream stream = new MemoryStream())
                {
                    model.filecollectionData.CopyTo(stream);
                    filebyte = stream.ToArray();
                    documentCollection.FileData = filebyte;
                   
                }
                documentCollection.MemberId = model.MemberId;
                documentCollection.DocumentCategoryId = model.DocumentCategoryId;
                documentCollection.FileName = model.filecollectionData.FileName;               
                documentCollection.FileCategory = "Application/Pdf";
                _Context.DocumentCollection.Add(documentCollection);
                _Context.SaveChanges();
                
            }
            
            return true;
        }
        public DocumentCollectionViewModel GetDocumentDetails(int id)
        {
            try
            {

                DocumentCollection document = _Context.DocumentCollection.Where(x => x.FileId == id)
                                                                            .Include(x => x.DocumentCategory)
                                                                            .FirstOrDefault();
                DocumentCollectionViewModel model = new DocumentCollectionViewModel
                {
                    Id = document.FileId,
                    MemberId = document.MemberId,
                    DocumentCategoryId = document.DocumentCategoryId,
                    DocumentCategoryName = document.DocumentCategory.Name,
                    FileName = document.FileName,
                    FileCategory = document.FileCategory
                };

                return model;
            }
            catch (Exception)
            {
                throw;
                //DocumentCollectionViewModel emptymodel = new DocumentCollectionViewModel();
                //return emptymodel;
            }
        }

        public bool DeleteDocument(int id)
        {
            try
            {
                DocumentCollection document = _Context.DocumentCollection.Where(x => x.FileId == id).FirstOrDefault();
                _Context.DocumentCollection.Remove(document);
                _Context.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public DocumentCollectionViewModel Create()
        {
            DocumentCollectionViewModel model = new DocumentCollectionViewModel();     
            model.DocumentList = new SelectList(_documentCategoryService.GetDocumentCategories(), "Id", "Name");
            return model;
        }
    }
}
