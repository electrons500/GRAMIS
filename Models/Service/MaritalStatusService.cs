using GRAMIS.Models.Data.GramisContext;
using GRAMIS.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GRAMIS.Models.Service
{
    public class MaritalStatusService
    {
        private GRAMISContext _Context;
        public MaritalStatusService(GRAMISContext context)
        {
            _Context = context;
        }
        public List<MaritalStatusViewModel> GetMaritalStatus()
        {
            try
            {
                var maritalStatus = _Context.Marital.ToList();
                List<MaritalStatusViewModel> model = maritalStatus.Select(x => new MaritalStatusViewModel
                {
                    Id = x.MaritalId,
                    Name = x.Name
                }).ToList();

                return model;
            }
            catch (Exception)
            {

                List<MaritalStatusViewModel> emptymodel = new List<MaritalStatusViewModel>();
                return emptymodel;
            }

        }

    }
}
