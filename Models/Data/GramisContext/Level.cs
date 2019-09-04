using System;
using System.Collections.Generic;

namespace GRAMIS.Models.Data.GramisContext
{
    public partial class Level
    {
        public Level()
        {
            Member = new HashSet<Member>();
        }

        public int LevelId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Member> Member { get; set; }
    }
}
