using System;
using System.Collections.Generic;

namespace GRAMIS.Models.Data.GramisContext
{
    public partial class Region
    {
        public Region()
        {
            Member = new HashSet<Member>();
        }

        public int RegionId { get; set; }
        public string RegionName { get; set; }

        public virtual ICollection<Member> Member { get; set; }
    }
}
