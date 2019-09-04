using GRAMIS.Models.Data.GramisContext;
using GRAMIS.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GRAMIS.Models.Service
{
    public class RankService
    {
        private GRAMISContext _Context;
        public RankService(GRAMISContext context)
        {
            _Context = context;
        }

        public bool AddNewRank(RankViewModel model)
        {
            Rank rank = new Rank {              
               Name = model.Name
            };
            _Context.Rank.Add(rank);
            _Context.SaveChanges();

            return true;
        }
        public List<RankViewModel> GetRanks()
        {
            try
            {
                var ranks = _Context.Rank.ToList();
                List<RankViewModel> model = ranks.Select(x => new RankViewModel
                {
                    Id = x.RankId,
                    Name = x.Name
                }).ToList();

                return model;
            }
            catch (Exception)
            {

                List<RankViewModel> emptymodel = new List<RankViewModel>();
                return emptymodel;
            }
            
        }

        public RankViewModel GetRankDetails(int id)
        {
            try
            {
                Rank rank = _Context.Rank.Where(x => x.RankId == id).First();
                RankViewModel model = new RankViewModel {
                    Id = rank.RankId,
                    Name = rank.Name
                };

                return model;
            }
            catch (Exception)
            {

                RankViewModel emptymodel = new RankViewModel();
                return emptymodel;
            }
        }
        public bool UpdateRank(RankViewModel model)
        {
            try
            {
                Rank rank = _Context.Rank.Where(x => x.RankId == model.Id).First();
                rank.Name = model.Name;
                _Context.Rank.Update(rank);
                _Context.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteRank(int id)
        {
            try
            {
                Rank rank = _Context.Rank.Where(x => x.RankId == id).FirstOrDefault();
                _Context.Rank.Remove(rank);
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
