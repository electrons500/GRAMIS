using GRAMIS.Models.Data.GramisContext;
using GRAMIS.Models.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GRAMIS.Models.Service
{
    public class MemberService
    {
        private GRAMISContext _context;
        private GenderService _GenderService;
        private RegionService _RegionService;
        private MaritalStatusService _MaritalStatusService;
        private AcademicYearService _AcademicYearService;
        private PaginatedList _LevelService;
        private RankService _RankService;

        public MemberService(GRAMISContext context,GenderService genderService,RegionService regionService, MaritalStatusService maritalStatusService,AcademicYearService academicYearService,PaginatedList levelService,RankService rankService)
        {
            _context = context;
            _GenderService = genderService;
            _RegionService = regionService;
            _MaritalStatusService = maritalStatusService;
            _AcademicYearService = academicYearService;
            _LevelService = levelService;
            _RankService = rankService;
        }

        public List<MemberViewModel> GetMembers()
        {
            try
            {
                List<Member> member = _context.Member
                                                .Include(x => x.Gender)
                                                .Include(x => x.Region)
                                                .Include(x => x.Marital)
                                                .Include(x => x.AcademicYear)
                                                .Include(x => x.Level)
                                                .Include(x => x.Rank)
                                                .Include(x => x.MemberImage)
                                                .ToList();

                List<MemberViewModel> viewModel = member.Select(x => new MemberViewModel
                {                  
                    Id = x.MemberId,
                    Firstname = x.Firstname,
                    Othername = x.Othername,
                    Surname = x.Surname,
                    Fullname = $"{x.Firstname} {x.Othername} {x.Surname}",
                    BirthDate = x.BirthDate,

                    GenderId = x.GenderId,
                    GenderName = x.Gender.GenderName,

                    Hometown = x.Hometown,
                    Address = x.Address,

                    RegionId = x.RegionId,
                    RegionName = x.Region.RegionName,

                    PhoneNumber = x.PhoneNumber,

                    MaritalId = x.MaritalId,
                    MaritalName = x.Marital.Name,

                    CurrentSchool = x.CurrentSchool,

                    AcademicYearId = x.AcademicYearId,
                    AcademicYearName = x.AcademicYear.Year,

                    Course = x.Course,

                    LevelId = x.LevelId,
                    LevelName = x.Level.Name,

                    AcademicQ = x.AcademicQ,
                    ProfQ = x.ProfQ,
                    Staffid = x.Staffid,
                   
                    RankId = x.RankId,
                    RankName = x.Rank.Name,

                    Regno = x.Regno,
                    Ssfno = x.Ssfno,
                    MemberImageId = x.MemberImageId,
                    Picture = x.MemberImage.Image

                }).ToList();

                return viewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public MemberViewModel GetMemberDetails(int id)
        {
            try
            {
                Member member = _context.Member.Where(x => x.MemberId == id)
                                                .Include(x => x.Gender)
                                                .Include(x => x.Region)
                                                .Include(x => x.Marital)
                                                .Include(x => x.AcademicYear)
                                                .Include(x => x.Level)
                                                .Include(x => x.Rank)
                                                .Include(x => x.MemberImage)
                                                .FirstOrDefault();

                MemberViewModel viewModel = new MemberViewModel
                {
                    Id = member.MemberId,
                    Firstname = member.Firstname,
                    Othername = member.Othername,
                    Surname = member.Surname,
                    Fullname = $"{member.Firstname} {member.Othername} {member.Surname}",
                    BirthDate = member.BirthDate,
                    GenderId = member.GenderId,
                    GenderName = member.Gender.GenderName,
                    Hometown = member.Hometown,
                    Address = member.Address,
                    RegionId = member.RegionId,
                    RegionName = member.Region.RegionName,
                    PhoneNumber = member.PhoneNumber,
                    MaritalId = member.MaritalId,
                    MaritalName = member.Marital.Name,
                    CurrentSchool = member.CurrentSchool,
                    AcademicYearId = member.AcademicYearId,
                    AcademicYearName = member.AcademicYear.Year,
                    Course = member.Course,
                    LevelId = member.LevelId,
                    LevelName = member.Level.Name,
                    AcademicQ = member.AcademicQ,
                    ProfQ = member.ProfQ,
                    Staffid = member.Staffid,
                    RankId = member.RankId,
                    RankName = member.Rank.Name,
                    Regno = member.Regno,
                    Ssfno = member.Ssfno,
                    MemberImageId = member.MemberImageId,                 
                    Picture = member.MemberImage.Image,
                    GenderList = new SelectList(_GenderService.GetGender(),"Id","GenderName"),
                    LevelList = new SelectList(_LevelService.GetLevel(),"Id","Name"),
                    MaritalList = new SelectList(_MaritalStatusService.GetMaritalStatus(),"Id","Name"),
                    AcademicyearList = new SelectList(_AcademicYearService.GetAcademicYear(),"Id","Year"),
                    RegionList = new SelectList(_RegionService.GetRegions(),"Id","RegionName"),
                    RankList = new SelectList(_RankService.GetRanks(),"Id","Name")
                   
                };

                return viewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public MemberViewModel Create()
        {
            MemberViewModel model = new MemberViewModel();
            model.GenderList = new SelectList(_GenderService.GetGender(), "Id", "GenderName");
            model.LevelList = new SelectList(_LevelService.GetLevel(), "Id", "Name");
            model.MaritalList = new SelectList(_MaritalStatusService.GetMaritalStatus(), "Id", "Name");
            model.AcademicyearList = new SelectList(_AcademicYearService.GetAcademicYear(), "Id", "Year");
            model.RegionList = new SelectList(_RegionService.GetRegions(), "Id", "RegionName");
            model.RankList = new SelectList(_RankService.GetRanks(), "Id", "Name");
            
            return model;
        }
        public bool AddMember(MemberViewModel model)
        {
            try
            {
                MemberImage image = new MemberImage();
                Member member = new Member();
                if (model.Memberphoto != null)
                {
                    byte[] imageByte;

                    using (var memoryStream = new MemoryStream())
                    {
                        model.Memberphoto.CopyTo(memoryStream);
                        imageByte = memoryStream.ToArray();
                    }

                    image = new MemberImage
                    {
                        Image = imageByte
                    };

                    _context.MemberImage.Add(image);
                    _context.SaveChanges();
                    member.MemberImageId = image.MemberImageId;

                }

                member.MemberId = model.Id;
                member.Firstname = model.Firstname;
                member.Othername = model.Othername;
                member.Surname = model.Surname;
                member.Fullname = $"{model.Firstname} {model.Othername} {model.Surname}";
                member.BirthDate = model.BirthDate;
                member.GenderId = model.GenderId;
                member.Hometown = model.Hometown;
                member.Address = model.Address;
                member.RegionId = model.RegionId;
                member.PhoneNumber = model.PhoneNumber;
                member.MaritalId = model.MaritalId;
                member.CurrentSchool = "KNUST";
                member.AcademicYearId = model.AcademicYearId;
                member.Course = model.Course;
                member.LevelId = model.LevelId;
                member.AcademicQ = model.AcademicQ;
                member.ProfQ = model.ProfQ;
                member.Staffid = model.Staffid;
                member.RankId = model.RankId;
                member.Regno = model.Regno;
                member.Ssfno = model.Ssfno;

                _context.Member.Add(member);
                _context.SaveChanges();

               
                return true;
            }
            catch (Exception)
            {
                throw;
                //return false;
            }
        }

        public bool UpdateMember(MemberViewModel model)
        {
            try
            {
                MemberImage image = new MemberImage();
                Member member = new Member();
                if (model.Memberphoto != null && model.Memberphoto != null)
                {
                    image = _context.MemberImage.Where(x => x.MemberImageId == model.MemberImageId).FirstOrDefault();

                    byte[] imageByte = new byte[model.Memberphoto.Length];

                    using (var memoryStream = new MemoryStream())
                    {
                        model.Memberphoto.CopyTo(memoryStream);
                        imageByte = memoryStream.ToArray();
                    }

                    image.Image = imageByte;
                    _context.MemberImage.Update(image);
                    _context.SaveChanges();
                   member.MemberImageId = image.MemberImageId;

                }

                if (model.MemberImageId == null && model.Memberphoto != null)
                {
                    byte[] imageByte;

                    using (var memoryStream = new MemoryStream())
                    {
                        model.Memberphoto.CopyTo(memoryStream);
                        imageByte = memoryStream.ToArray();
                    }

                    image = new MemberImage
                    {
                        Image = imageByte
                    };

                    _context.MemberImage.Add(image);
                    _context.SaveChanges();
                    member.MemberImageId = image.MemberImageId;
                }

                member = _context.Member.Where(x => x.MemberId == model.Id).FirstOrDefault();
                member.Firstname = model.Firstname;
                member.Othername = model.Othername;
                member.Surname = model.Surname;
                member.Fullname = $"{model.Firstname} {model.Othername} {model.Surname}";
                member.BirthDate = model.BirthDate;
                member.GenderId = model.GenderId;
                member.Hometown = model.Hometown;
                member.Address = model.Address;
                member.RegionId = model.RegionId;
                member.PhoneNumber = model.PhoneNumber;
                member.MaritalId = model.MaritalId;
                member.CurrentSchool = "KNUST";
                member.AcademicYearId = model.AcademicYearId;
                member.Course = model.Course;
                member.LevelId = model.LevelId;
                member.AcademicQ = model.AcademicQ;
                member.ProfQ = model.ProfQ;
                member.Staffid = model.Staffid;
                member.RankId = model.RankId;
                member.Regno = model.Regno;
                member.Ssfno = model.Ssfno;
           
                _context.Member.Update(member);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteMember(int id)
        {  
            try
            {
                Member member = _context.Member.Where(x => x.MemberId == id).FirstOrDefault();

                _context.Member.Remove(member);

                if (member.MemberImageId != null)
                {
                    MemberImage image = _context.MemberImage.Where(x => x.MemberImageId == member.MemberImageId).FirstOrDefault();
                    _context.MemberImage.Remove(image);
                }

                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<MemberViewModel> SearchMembers(string fullname)
        {
            try
            {
                List<Member> member = _context.Member
                                                .Where(x => x.Fullname.Contains(fullname))
                                                .Include(x => x.Gender)
                                                .Include(x => x.Region)
                                                .Include(x => x.Marital)
                                                .Include(x => x.AcademicYear)
                                                .Include(x => x.Level)
                                                .Include(x => x.Rank)
                                                .Include(x => x.MemberImage)
                                                .ToList();

                List<MemberViewModel> viewModel = member.Select(x => new MemberViewModel
                {
                    Id = x.MemberId,
                    Firstname = x.Firstname,
                    Othername = x.Othername,
                    Surname = x.Surname,
                    Fullname = $"{x.Firstname} {x.Othername} {x.Surname}",
                    BirthDate = x.BirthDate,

                    GenderId = x.GenderId,
                    GenderName = x.Gender.GenderName,

                    Hometown = x.Hometown,
                    Address = x.Address,

                    RegionId = x.RegionId,
                    RegionName = x.Region.RegionName,

                    PhoneNumber = x.PhoneNumber,

                    MaritalId = x.MaritalId,
                    MaritalName = x.Marital.Name,

                    CurrentSchool = x.CurrentSchool,

                    AcademicYearId = x.AcademicYearId,
                    AcademicYearName = x.AcademicYear.Year,

                    Course = x.Course,

                    LevelId = x.LevelId,
                    LevelName = x.Level.Name,

                    AcademicQ = x.AcademicQ,
                    ProfQ = x.ProfQ,
                    Staffid = x.Staffid,

                    RankId = x.RankId,
                    RankName = x.Rank.Name,

                    Regno = x.Regno,
                    Ssfno = x.Ssfno,
                    MemberImageId = x.MemberImageId,
                    Picture = x.MemberImage.Image

                }).ToList();

                return viewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
