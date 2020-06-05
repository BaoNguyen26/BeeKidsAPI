using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BeeKid.API.Models
{
    public partial class DB_Context : DbContext
    {
        public DB_Context()
        {
        }

        public DB_Context(DbContextOptions<DB_Context> options)
            : base(options)
        {
        }

        public virtual DbSet<TbBenefitPartner> TbBenefitPartner { get; set; }
        public virtual DbSet<TbCenter> TbCenter { get; set; }
        public virtual DbSet<TbEvent> TbEvent { get; set; }
        public virtual DbSet<TbExpert> TbExpert { get; set; }
        public virtual DbSet<TbHandBook> TbHandBook { get; set; }
        public virtual DbSet<TbPartner> TbPartner { get; set; }
        public virtual DbSet<TbSection1> TbSection1 { get; set; }
        public virtual DbSet<TbSection2> TbSection2 { get; set; }
        public virtual DbSet<TbSignUp> TbSignUp { get; set; }
        public virtual DbSet<TbSignUpPartnerr> TbSignUpPartnerr { get; set; }
        public virtual DbSet<TbSlide> TbSlide { get; set; }
        public virtual DbSet<TbTypePartner> TbTypePartner { get; set; }
        public virtual DbSet<TbWebContact> TbWebContact { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=BeekidsDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbBenefitPartner>(entity =>
            {
                entity.HasKey(e => e.BpId);

                entity.ToTable("tbBenefitPartner");

                entity.Property(e => e.BpId).HasColumnName("BP_ID");

                entity.Property(e => e.BpCheck).HasColumnName("BP_CHECK");

                entity.Property(e => e.BpDescription).HasColumnName("BP_DESCRIPTION");

                entity.Property(e => e.BpImg).HasColumnName("BP_IMG");

                entity.Property(e => e.BpSubDescription).HasColumnName("BP_SUB_DESCRIPTION");

                entity.Property(e => e.BpTab).HasColumnName("BP_TAB");

                entity.Property(e => e.BpTitle).HasColumnName("BP_TITLE");
            });

            modelBuilder.Entity<TbCenter>(entity =>
            {
                entity.HasKey(e => e.CenterId);

                entity.ToTable("tbCenter");

                entity.Property(e => e.CenterId).HasColumnName("CENTER_ID");

                entity.Property(e => e.CenterName).HasColumnName("CENTER_NAME");
            });

            modelBuilder.Entity<TbEvent>(entity =>
            {
                entity.HasKey(e => e.EventId);

                entity.ToTable("tbEvent");

                entity.Property(e => e.EventId).HasColumnName("EVENT_ID");

                entity.Property(e => e.AdminuserId)
                    .HasColumnName("ADMINUSER_ID")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.EventContent).HasColumnName("EVENT_CONTENT");

                entity.Property(e => e.EventDatetime)
                    .HasColumnName("EVENT_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.EventDescription).HasColumnName("EVENT_DESCRIPTION");

                entity.Property(e => e.EventImage).HasColumnName("EVENT_IMAGE");

                entity.Property(e => e.EventLink).HasColumnName("EVENT_LINK");

                entity.Property(e => e.EventName).HasColumnName("EVENT_NAME");

                entity.Property(e => e.EventTagname).HasColumnName("EVENT_TAGNAME");
            });

            modelBuilder.Entity<TbExpert>(entity =>
            {
                entity.HasKey(e => e.ExpertId);

                entity.ToTable("tbExpert");

                entity.Property(e => e.ExpertId).HasColumnName("EXPERT_ID");

                entity.Property(e => e.ExpertImgae).HasColumnName("EXPERT_IMGAE");

                entity.Property(e => e.ExpertJob).HasColumnName("EXPERT_JOB");

                entity.Property(e => e.ExpertName).HasColumnName("EXPERT_NAME");
            });

            modelBuilder.Entity<TbHandBook>(entity =>
            {
                entity.HasKey(e => e.HbId);

                entity.ToTable("tbHandBook");

                entity.Property(e => e.HbId).HasColumnName("HB_ID");

                entity.Property(e => e.AdminuserId).HasColumnName("ADMINUSER_ID");

                entity.Property(e => e.HbDatetime)
                    .HasColumnName("HB_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.HbDescription).HasColumnName("HB_DESCRIPTION");

                entity.Property(e => e.HbTitle).HasColumnName("HB_TITLE");
            });

            modelBuilder.Entity<TbPartner>(entity =>
            {
                entity.HasKey(e => e.PartnerId);

                entity.ToTable("tbPartner");

                entity.Property(e => e.PartnerId).HasColumnName("PARTNER_ID");

                entity.Property(e => e.PartnerContent).HasColumnName("PARTNER_CONTENT");

                entity.Property(e => e.PartnerImage).HasColumnName("PARTNER_IMAGE");

                entity.Property(e => e.TypepartnerId).HasColumnName("TYPEPARTNER_ID");
            });

            modelBuilder.Entity<TbSection1>(entity =>
            {
                entity.HasKey(e => e.Section1Id);

                entity.ToTable("tbSection1");

                entity.Property(e => e.Section1Id).HasColumnName("SECTION1_ID");

                entity.Property(e => e.Section1Delivery).HasColumnName("SECTION1_DELIVERY");

                entity.Property(e => e.Section1Description).HasColumnName("SECTION1_DESCRIPTION");

                entity.Property(e => e.Section1Price).HasColumnName("SECTION1_PRICE");

                entity.Property(e => e.Section1Product).HasColumnName("SECTION1_PRODUCT");

                entity.Property(e => e.Section1Quality).HasColumnName("SECTION1_QUALITY");

                entity.Property(e => e.Section1Title).HasColumnName("SECTION1_TITLE");
            });

            modelBuilder.Entity<TbSection2>(entity =>
            {
                entity.HasKey(e => e.Section2Id);

                entity.ToTable("tbSection2");

                entity.Property(e => e.Section2Id).HasColumnName("SECTION2_ID");

                entity.Property(e => e.Section2Brain).HasColumnName("SECTION2_BRAIN");

                entity.Property(e => e.Section2Creation).HasColumnName("SECTION2_CREATION");

                entity.Property(e => e.Section2Description).HasColumnName("SECTION2_DESCRIPTION");

                entity.Property(e => e.Section2Image).HasColumnName("SECTION2_IMAGE");

                entity.Property(e => e.Section2Motor).HasColumnName("SECTION2_MOTOR");

                entity.Property(e => e.Section2Thinking).HasColumnName("SECTION2_THINKING");

                entity.Property(e => e.Section2Title).HasColumnName("SECTION2_TITLE");
            });

            modelBuilder.Entity<TbSignUp>(entity =>
            {
                entity.HasKey(e => e.SignupId);

                entity.ToTable("tbSignUp");

                entity.Property(e => e.SignupId)
                    .HasColumnName("SIGNUP_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CenterId).HasColumnName("CENTER_ID");

                entity.Property(e => e.SignupEmail).HasColumnName("SIGNUP_EMAIL");

                entity.Property(e => e.SignupName).HasColumnName("SIGNUP_NAME");

                entity.Property(e => e.SignupPhonenb).HasColumnName("SIGNUP_PHONENB");
            });

            modelBuilder.Entity<TbSignUpPartnerr>(entity =>
            {
                entity.HasKey(e => e.SpId);

                entity.ToTable("tbSignUpPartnerr");

                entity.Property(e => e.SpId).HasColumnName("SP_ID");

                entity.Property(e => e.SpContent).HasColumnName("SP_CONTENT");

                entity.Property(e => e.SpImage).HasColumnName("SP_IMAGE");
            });

            modelBuilder.Entity<TbSlide>(entity =>
            {
                entity.HasKey(e => e.SlideId);

                entity.ToTable("tbSlide");

                entity.Property(e => e.SlideId).HasColumnName("SLIDE_ID");

                entity.Property(e => e.SlideDescription).HasColumnName("SLIDE_DESCRIPTION");

                entity.Property(e => e.SlideImage).HasColumnName("SLIDE_IMAGE");

                entity.Property(e => e.SlideSubtitle).HasColumnName("SLIDE_SUBTITLE");

                entity.Property(e => e.SlideTitle).HasColumnName("SLIDE_TITLE");
            });

            modelBuilder.Entity<TbTypePartner>(entity =>
            {
                entity.HasKey(e => e.TypepartnerId);

                entity.ToTable("tbTypePartner");

                entity.Property(e => e.TypepartnerId).HasColumnName("TYPEPARTNER_ID");

                entity.Property(e => e.TypepartnerName).HasColumnName("TYPEPARTNER_NAME");
            });

            modelBuilder.Entity<TbWebContact>(entity =>
            {
                entity.HasKey(e => e.WebcontactId);

                entity.ToTable("tbWebContact");

                entity.Property(e => e.WebcontactId).HasColumnName("WEBCONTACT_ID");

                entity.Property(e => e.WebcontactAddress).HasColumnName("WEBCONTACT_ADDRESS");

                entity.Property(e => e.WebcontactDescription).HasColumnName("WEBCONTACT_DESCRIPTION");

                entity.Property(e => e.WebcontactEmail).HasColumnName("WEBCONTACT_EMAIL");

                entity.Property(e => e.WebcontactFanbage).HasColumnName("WEBCONTACT_FANBAGE");

                entity.Property(e => e.WebcontactLogo).HasColumnName("WEBCONTACT_LOGO");

                entity.Property(e => e.WebcontactPhonenb).HasColumnName("WEBCONTACT_PHONENB");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
