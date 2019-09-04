using System;
using System.Collections.Generic;

namespace GRAMIS.Models.Data.GramisContext
{
    public partial class DocumentCollection
    {
        public int FileId { get; set; }
        public int MemberId { get; set; }
        public int DocumentCategoryId { get; set; }
        public string FileName { get; set; }
        public string FileCategory { get; set; }
        public byte[] FileData { get; set; }

        public virtual DocumentCategories DocumentCategory { get; set; }
        public virtual Member Member { get; set; }
    }
}
