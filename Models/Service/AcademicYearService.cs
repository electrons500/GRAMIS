using GRAMIS.Models.Data.GramisContext;
using GRAMIS.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GRAMIS.Models.Service
{
    public class AcademicYearService
    {
        private GRAMISContext _Context;
        public AcademicYearService(GRAMISContext Context)
        {
            _Context = Context;
        }

        public bool AddAcademicYear(AcademicYearViewModel model)
        {
            AcademicYear academicYear = new AcademicYear
            {
                AcademicYearId = model.Id,
                Year = model.Year
            };
            _Context.AcademicYear.Add(academicYear);
            _Context.SaveChanges();

            return true;
        }
        public List<AcademicYearViewModel> GetAcademicYear()
        {
            try
            {
                var academicyear = _Context.AcademicYear.ToList();
                List<AcademicYearViewModel> model = academicyear.Select(x => new AcademicYearViewModel
                {
                   Id = x.AcademicYearId,
                   Year = x.Year

                }).ToList();

                return model;
            }
            catch (Exception)
            {

                List<AcademicYearViewModel> emptymodel = new List<AcademicYearViewModel>();
                return emptymodel;
            }

        }

        public AcademicYearViewModel GetAcademicYearDetails(int id)
        {
            try
            {
                AcademicYear academicYear = _Context.AcademicYear.Where(x => x.AcademicYearId == id).First();
                AcademicYearViewModel model = new AcademicYearViewModel
                {
                   Id = academicYear.AcademicYearId,
                   Year = academicYear.Year

                };

                return model;
            }
            catch (Exception)
            {

                AcademicYearViewModel emptymodel = new AcademicYearViewModel();
                return emptymodel;
            }
        }

        public bool UpdateAcademicYear(AcademicYearViewModel model)
        {
            try
            {
                AcademicYear academicYear = _Context.AcademicYear.Where(x => x.AcademicYearId == model.Id).First();
                academicYear.Year = model.Year;

                _Context.AcademicYear.Update(academicYear);
                _Context.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteAcademicYear(int id)
        {
            try
            {
                AcademicYear academicYear = _Context.AcademicYear.Where(x => x.AcademicYearId == id).FirstOrDefault();
                _Context.AcademicYear.Remove(academicYear);
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
