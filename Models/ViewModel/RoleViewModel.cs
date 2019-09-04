using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GRAMIS.Models.ViewModel
{
    public class RoleViewModel
    {
        [Key]
        public string RoleId { get; set; }
        [DisplayName("Role Category")]
        public string RoleName { get; set; }
    }
}
