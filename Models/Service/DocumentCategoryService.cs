using GRAMIS.Models.Data.GramisContext;
using GRAMIS.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GRAMIS.Models.Service
{
    public class DocumentCategoryService
    {
        private GRAMISContext _Context;
        public DocumentCategoryService(GRAMISContext context)
        {
            _Context = context;
        }

        public bool AddDocumentCategory(DocumentCategoriesViewModel model)
        {
            DocumentCategories documentCategories = new DocumentCategories
            {
                Name = model.Name
            };
            _Context.DocumentCategories.Add(documentCategories);
            _Context.SaveChanges();

            return true;
        }
        public List<DocumentCategoriesViewModel> GetDocumentCategories()
        {
            try
            {
                var documentCategories = _Context.DocumentCategories.ToList();
                List<DocumentCategoriesViewModel> model = documentCategories.Select(x => new DocumentCategoriesViewModel
                {
                    Id = x.DocumentCategoryId,
                    Name = x.Name
                }).ToList();

                return model;
            }
            catch (Exception)
            {

                List<DocumentCategoriesViewModel> emptymodel = new List<DocumentCategoriesViewModel>();
                return emptymodel;
            }

        }

        public DocumentCategoriesViewModel GetDocumentCategoriesDetails(int id)
        {
            try
            {
                DocumentCategories documentCategories = _Context.DocumentCategories.Where(x => x.DocumentCategoryId == id).First();
                DocumentCategoriesViewModel model = new DocumentCategoriesViewModel
                {
                    Id = documentCategories.DocumentCategoryId,
                    Name = documentCategories.Name
                };

                return model;
            }
            catch (Exception)
            {

                DocumentCategoriesViewModel emptymodel = new DocumentCategoriesViewModel();
                return emptymodel;
            }
        }

        public bool UpdateDocumentCategories(DocumentCategoriesViewModel model)
        {
            try
            {
                DocumentCategories documentCategories = _Context.DocumentCategories.Where(x => x.DocumentCategoryId == model.Id).First();
                documentCategories.Name = model.Name;
                _Context.DocumentCategories.Update(documentCategories);
                _Context.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool DeleteDocumentCategories(int id)
        {
            try
            {
                DocumentCategories documentCategories = _Context.DocumentCategories.Where(x => x.DocumentCategoryId == id).FirstOrDefault();
                _Context.DocumentCategories.Remove(documentCategories);
                _Context.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

    }
}
