using System;
using System.Collections.Generic;

namespace GRAMIS.Models.Data.GramisContext
{
    public partial class DocumentCategories
    {
        public DocumentCategories()
        {
            DocumentCollection = new HashSet<DocumentCollection>();
        }

        public int DocumentCategoryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<DocumentCollection> DocumentCollection { get; set; }
    }
}
