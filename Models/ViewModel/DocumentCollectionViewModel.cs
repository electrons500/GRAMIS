using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GRAMIS.Models.ViewModel
{
    public class DocumentCollectionViewModel
    {
        [Key]
        public int Id { get; set; } 

        [DataType(DataType.Text)]
        [Display(Name = "Student ID")]
        
        public int MemberId { get; set; }
        [Display(Name ="Document Category")]
        [Required(ErrorMessage ="This field is required")]
        public int DocumentCategoryId { get; set; }
        [NotMapped]
        public string DocumentCategoryName { get; set; }
        [NotMapped]
        public SelectList DocumentList { get; set; }
        [NotMapped]
        public string DocumentName { get; set; }
        [Display(Name = "Document Name")]      
        public string FileName { get; set; }
        public string FileCategory { get; set; }
        [NotMapped]
        public byte[] FileData { get; set; }
        [NotMapped]
        [Display(Name = "Upload Document")]
        [Required(ErrorMessage = "This field is required")]
        public IFormFile filecollectionData { get; set; }

    }
}
