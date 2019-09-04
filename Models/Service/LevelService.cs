using GRAMIS.Models.Data.GramisContext;
using GRAMIS.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GRAMIS.Models.Service
{
    public class PaginatedList
    {
        private GRAMISContext _Context;
        public PaginatedList(GRAMISContext context)
        {
            _Context = context;
        }
        public List<LevelViewModel> GetLevel()
        {
            try
            {
                var level = _Context.Level.ToList();
                List<LevelViewModel> model = level.Select(x => new LevelViewModel
                {
                    Id = x.LevelId,
                   Name = x.Name
                }).ToList();

                return model;
            }
            catch (Exception)
            {

                List<LevelViewModel> emptymodel = new List<LevelViewModel>();
                return emptymodel;
            }

        }
    }
}
