using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GRAMIS.Models.ViewModel
{
    public class MemberViewModel
    {
        [Key]
        [Required]
        [Display(Name ="Student ID")]
        [DataType(DataType.Text)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string Firstname { get; set; }
        
        [Display(Name = "Othername")]
        public string Othername { get; set; }
        [Required]
        [Display(Name = "Surname")]
        public string Surname { get; set; }
        [NotMapped]
        [Display(Name = "Name")]
        public string Fullname { get; set; }
        
        
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Gender/Sex")]
        public int GenderId { get; set; }
        [NotMapped]
        public string GenderName { get; set; }
        [NotMapped]
        public SelectList GenderList { get; set; }


        [Required]
        [Display(Name = "Hometown")]
        public string Hometown { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Region")]
        public int RegionId { get; set; }
        [NotMapped]
        public string RegionName { get; set; }
        [NotMapped]
        public SelectList RegionList { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Marital Status")]
        public int MaritalId { get; set; }
        [NotMapped]
        public string MaritalName { get; set; }
        [NotMapped]
        public SelectList MaritalList { get; set; }

        [Display(Name = "Management Unit")]
        public string CurrentSchool { get; set; }

        [Display(Name = "Academic year(Admission)")]
        public int AcademicYearId { get; set; }
        [NotMapped]
        public string AcademicYearName { get; set; }
        [NotMapped]
        public SelectList AcademicyearList { get; set; }

        [Required]
        [Display(Name = "Course")]
        public string Course { get; set; }

        [Display(Name = "Level")]
        public int LevelId { get; set; }
        [NotMapped]
        public string LevelName { get; set; }
        [NotMapped]
        public SelectList LevelList { get; set; }

        [Required]
        [Display(Name = "Academic Qualifaction")]
        public string AcademicQ { get; set; }
        [Required]
        [Display(Name = "Professional Qualification")]
        public string ProfQ { get; set; }
        [Required]
        [Display(Name = "Staff ID")]
        public string Staffid { get; set; }

        [Display(Name = "GES Rank")]
        public int RankId { get; set; }
        [NotMapped]
        public string RankName { get; set; }
        [NotMapped]
        public SelectList RankList { get; set; }

        [Required]
        [Display(Name = "Registration Number")]
        public string Regno { get; set; }
        [Required]
        [Display(Name = "SSNIT Number")]
        public string Ssfno { get; set; }
        public int? MemberImageId { get; set; }
        [NotMapped]
        [Display(Name = "Member photo")]
        public IFormFile Memberphoto { get; set; }
        [DisplayName("Image")]
        [NotMapped]
        public byte[] Picture { get; set; }
       
    }
}
