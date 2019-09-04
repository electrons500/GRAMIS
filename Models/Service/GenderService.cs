using GRAMIS.Models.Data.GramisContext;
using GRAMIS.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GRAMIS.Models.Service
{
    public class GenderService
    {
        private GRAMISContext _Context;
        public GenderService(GRAMISContext context)
        {
            _Context = context;
        }
        public List<GenderViewModel> GetGender()
        {
            try
            {
                var gender = _Context.Gender.ToList();
                List<GenderViewModel> model = gender.Select(x => new GenderViewModel
                {
                    Id = x.GenderId,
                    GenderName = x.GenderName
                }).ToList();

                return model;
            }
            catch (Exception)
            {

                List<GenderViewModel> emptymodel = new List<GenderViewModel>();
                return emptymodel;
            }

        }
    }
}
