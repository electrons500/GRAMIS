using System;
using System.Collections.Generic;

namespace GRAMIS.Models.Data.GramisContext
{
    public partial class Gender
    {
        public Gender()
        {
            Member = new HashSet<Member>();
        }

        public int GenderId { get; set; }
        public string GenderName { get; set; }

        public virtual ICollection<Member> Member { get; set; }
    }
}
