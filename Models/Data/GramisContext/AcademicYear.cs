using System;
using System.Collections.Generic;

namespace GRAMIS.Models.Data.GramisContext
{
    public partial class AcademicYear
    {
        public AcademicYear()
        {
            Member = new HashSet<Member>();
        }

        public int AcademicYearId { get; set; }
        public string Year { get; set; }

        public virtual ICollection<Member> Member { get; set; }
    }
}
