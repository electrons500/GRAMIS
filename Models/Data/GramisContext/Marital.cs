using System;
using System.Collections.Generic;

namespace GRAMIS.Models.Data.GramisContext
{
    public partial class Marital
    {
        public Marital()
        {
            Member = new HashSet<Member>();
        }

        public int MaritalId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Member> Member { get; set; }
    }
}
