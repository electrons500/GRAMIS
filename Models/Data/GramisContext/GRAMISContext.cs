using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using GRAMIS.Models.ViewModel;

namespace GRAMIS.Models.Data.GramisContext
{
    public partial class GRAMISContext : DbContext
    {
        public GRAMISContext()
        {
        }

        public GRAMISContext(DbContextOptions<GRAMISContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AcademicYear> AcademicYear { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<DocumentCategories> DocumentCategories { get; set; }
        public virtual DbSet<DocumentCollection> DocumentCollection { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Level> Level { get; set; }
        public virtual DbSet<Marital> Marital { get; set; }
        public virtual DbSet<Member> Member { get; set; }
        public virtual DbSet<MemberImage> MemberImage { get; set; }
        public virtual DbSet<Rank> Rank { get; set; }
        public virtual DbSet<Region> Region { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(connectionString:"DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<AcademicYear>(entity =>
            {
                entity.HasKey(e => e.AcademicYearId)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.AcademicYearId).HasColumnName("academicYearId");

                entity.Property(e => e.Year)
                    .IsRequired()
                    .HasColumnName("year")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_AspNetRolesAspNetRoleClaims");
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUsersAspNetUserClaims");
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey })
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUsersAspNetUserLogins");
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .ForSqlServerIsClustered(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_AspNetRolesAspNetUserRoles");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUsersAspNetUserRoles");
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name })
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUsersAspNetUserTokens");
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<DocumentCategories>(entity =>
            {
                entity.HasKey(e => e.DocumentCategoryId)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DocumentCollection>(entity =>
            {
                entity.HasKey(e => e.FileId)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.FileCategory)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FileData).IsRequired();

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.DocumentCategory)
                    .WithMany(p => p.DocumentCollection)
                    .HasForeignKey(d => d.DocumentCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentCategoriesDocumentCollection");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.DocumentCollection)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_memberDocumentCollection");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.HasKey(e => e.GenderId)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.GenderName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Level>(entity =>
            {
                entity.HasKey(e => e.LevelId)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("level");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Marital>(entity =>
            {
                entity.HasKey(e => e.MaritalId)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("marital");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasKey(e => e.MemberId)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("member");

                entity.Property(e => e.MemberId).ValueGeneratedNever();

                entity.Property(e => e.AcademicQ)
                    .HasColumnName("academicQ")
                    .HasMaxLength(50);

                entity.Property(e => e.AcademicYearId).HasColumnName("academicYearId");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(50);

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.Course)
                    .HasColumnName("course")
                    .HasMaxLength(50);

                entity.Property(e => e.CurrentSchool)
                    .HasColumnName("currentSchool")
                    .HasMaxLength(50);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname")
                    .HasMaxLength(50);

                entity.Property(e => e.Fullname)
                    .HasColumnName("fullname")
                    .HasMaxLength(100);

                entity.Property(e => e.Hometown)
                    .IsRequired()
                    .HasColumnName("hometown")
                    .HasMaxLength(50);

                entity.Property(e => e.Othername)
                    .HasColumnName("othername")
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasColumnName("phoneNumber")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ProfQ)
                    .HasColumnName("profQ")
                    .HasMaxLength(50);

                entity.Property(e => e.Regno)
                    .IsRequired()
                    .HasColumnName("regno")
                    .HasMaxLength(50);

                entity.Property(e => e.Ssfno)
                    .HasColumnName("ssfno")
                    .HasMaxLength(50);

                entity.Property(e => e.Staffid)
                    .HasColumnName("staffid")
                    .HasMaxLength(50);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasMaxLength(50);

                entity.HasOne(d => d.AcademicYear)
                    .WithMany(p => p.Member)
                    .HasForeignKey(d => d.AcademicYearId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AcademicYearmember");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Member)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gendermember");

                entity.HasOne(d => d.Level)
                    .WithMany(p => p.Member)
                    .HasForeignKey(d => d.LevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_levelmember");

                entity.HasOne(d => d.Marital)
                    .WithMany(p => p.Member)
                    .HasForeignKey(d => d.MaritalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_maritalmember");

                entity.HasOne(d => d.MemberImage)
                    .WithMany(p => p.Member)
                    .HasForeignKey(d => d.MemberImageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberImagemember");

                entity.HasOne(d => d.Rank)
                    .WithMany(p => p.Member)
                    .HasForeignKey(d => d.RankId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_rankmember");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Member)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Regionmember");
            });

            modelBuilder.Entity<MemberImage>(entity =>
            {
                entity.HasKey(e => e.MemberImageId)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Image).IsRequired();
            });

            modelBuilder.Entity<Rank>(entity =>
            {
                entity.HasKey(e => e.RankId)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("rank");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasKey(e => e.RegionId)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.RegionName)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }

        public DbSet<GRAMIS.Models.ViewModel.RoleViewModel> RoleViewModel { get; set; }

        public DbSet<GRAMIS.Models.ViewModel.RankViewModel> RankViewModel { get; set; }

        public DbSet<GRAMIS.Models.ViewModel.RegionViewModel> RegionViewModel { get; set; }

        public DbSet<GRAMIS.Models.ViewModel.AcademicYearViewModel> AcademicYearViewModel { get; set; }

        public DbSet<GRAMIS.Models.ViewModel.DocumentCategoriesViewModel> DocumentCategoriesViewModel { get; set; }

        public DbSet<GRAMIS.Models.ViewModel.MemberViewModel> MemberViewModel { get; set; }

        public DbSet<GRAMIS.Models.ViewModel.DocumentCollectionViewModel> DocumentCollectionViewModel { get; set; }
    }
}
