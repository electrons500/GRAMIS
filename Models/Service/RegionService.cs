using GRAMIS.Models.Data.GramisContext;
using GRAMIS.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GRAMIS.Models.Service
{
    public class RegionService
    {
        private GRAMISContext _Context;
        public RegionService(GRAMISContext Context)
        {
            _Context = Context;
        }
        public bool AddNewRegion(RegionViewModel model)
        {
            Region region = new Region
            {
                RegionId = model.Id,
                RegionName = model.RegionName
            };
            _Context.Region.Add(region);
            _Context.SaveChanges();

            return true;
        }

        public List<RegionViewModel> GetRegions()
        {
            try
            {
                var regions = _Context.Region.ToList();
                List<RegionViewModel> model = regions.Select(x => new RegionViewModel
                {
                   Id = x.RegionId,
                   RegionName = x.RegionName

                }).ToList();

                return model;
            }
            catch (Exception)
            {

                List<RegionViewModel> emptymodel = new List<RegionViewModel>();
                return emptymodel;
            }

        }
        public RegionViewModel GetRegionDetails(int id)
        {
            try
            {
                Region region = _Context.Region.Where(x => x.RegionId == id).First();
                RegionViewModel model = new RegionViewModel
                {
                   Id = region.RegionId,
                   RegionName = region.RegionName
                   
                };

                return model;
            }
            catch (Exception)
            {

                RegionViewModel emptymodel = new RegionViewModel();
                return emptymodel;
            }
        }

        public bool UpdateRegion(RegionViewModel model)
        {
            try
            {
                Region region = _Context.Region.Where(x => x.RegionId == model.Id).First();
                region.RegionName = model.RegionName;

                _Context.Region.Update(region);
                _Context.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteRegion(int id)
        {
            try
            {
                Region region = _Context.Region.Where(x => x.RegionId == id).FirstOrDefault();
                _Context.Region.Remove(region);
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
