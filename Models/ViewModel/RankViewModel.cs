using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GRAMIS.Models.ViewModel
{
    public class RankViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Rank")]
        public string Name { get; set; }
    }
}
