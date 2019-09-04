using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GRAMIS.Models.ViewModel
{
    public class AcademicYearViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Academic year")]
        public string Year { get; set; }
    }
}
