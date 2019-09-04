using System;
using System.Collections.Generic;

namespace GRAMIS.Models.Data.GramisContext
{
    public partial class Rank
    {
        public Rank()
        {
            Member = new HashSet<Member>();
        }

        public int RankId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Member> Member { get; set; }
    }
}
