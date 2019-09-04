using System;
using System.Collections.Generic;

namespace GRAMIS.Models.Data.GramisContext
{
    public partial class Member
    {
        public Member()
        {
            DocumentCollection = new HashSet<DocumentCollection>();
        }

        public int MemberId { get; set; }
        public string Firstname { get; set; }
        public string Othername { get; set; }
        public string Surname { get; set; }
        public string Fullname { get; set; }
        public DateTime BirthDate { get; set; }
        public int GenderId { get; set; }
        public string Hometown { get; set; }
        public string Address { get; set; }
        public int RegionId { get; set; }
        public string PhoneNumber { get; set; }
        public int MaritalId { get; set; }
        public string CurrentSchool { get; set; }
        public int AcademicYearId { get; set; }
        public string Course { get; set; }
        public int LevelId { get; set; }
        public string AcademicQ { get; set; }
        public string ProfQ { get; set; }
        public string Staffid { get; set; }
        public int RankId { get; set; }
        public string Regno { get; set; }
        public string Ssfno { get; set; }
        public int? MemberImageId { get; set; }

        public virtual AcademicYear AcademicYear { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Level Level { get; set; }
        public virtual Marital Marital { get; set; }
        public virtual MemberImage MemberImage { get; set; }
        public virtual Rank Rank { get; set; }
        public virtual Region Region { get; set; }
        public virtual ICollection<DocumentCollection> DocumentCollection { get; set; }
    }
}
