using System;
using System.Collections.Generic;

namespace GRAMIS.Models.Data.GramisContext
{
    public partial class MemberImage
    {
        public MemberImage()
        {
            Member = new HashSet<Member>();
        }

        public int MemberImageId { get; set; }
        public byte[] Image { get; set; }

        public virtual ICollection<Member> Member { get; set; }
    }
}
