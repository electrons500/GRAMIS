using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GRAMIS.Models.ViewModel
{
    public class RegionViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Region")]
        public string RegionName { get; set; }
    }
}
