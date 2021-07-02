﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace InstituteOfFineArt.Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Competition> Competitions { get; set; }
        public virtual DbSet<DetailBill> DetailBills { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<TestCore> TestCores { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-J31QKVVN\\HOANGSON;Database=InstituteOfFineArt;user id=sa;password=1234567");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Vietnamese_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.IdAcc)
                    .HasName("PK__account__6BE8F06404037904");

                entity.ToTable("account");

                entity.Property(e => e.IdAcc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("id_acc");

                entity.Property(e => e.Addr)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("addr");

                entity.Property(e => e.Avatar)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("avatar");

                entity.Property(e => e.ContestsParticipated)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("contests_participated");

                entity.Property(e => e.Datecreated)
                    .HasColumnType("datetime")
                    .HasColumnName("datecreated");

                entity.Property(e => e.Dateupdated)
                    .HasColumnType("datetime")
                    .HasColumnName("dateupdated");

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("dob");

                entity.Property(e => e.Email)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("fullname");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.IdRole)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("id_role");

                entity.Property(e => e.Pass)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("pass");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("phone_number");

                entity.Property(e => e.Stat).HasColumnName("stat");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.HasKey(e => e.IdBill)
                    .HasName("PK__bill__C56081F548B02DBA");

                entity.ToTable("bill");

                entity.Property(e => e.IdBill)
                    .HasMaxLength(100)
                    .HasColumnName("id_bill");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasColumnName("created");

                entity.Property(e => e.IdAcc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("id_acc");

                entity.Property(e => e.Total)
                    .HasColumnType("money")
                    .HasColumnName("total");

                entity.HasOne(d => d.IdAccNavigation)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.IdAcc)
                    .HasConstraintName("FK_bill_account");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.IdComment)
                    .HasName("PK__comment__7E14AC85A10BB091");

                entity.ToTable("comment");

                entity.Property(e => e.IdComment)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("id_comment");

                entity.Property(e => e.Datecomment)
                    .HasColumnType("datetime")
                    .HasColumnName("datecomment");

                entity.Property(e => e.IdAcc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("id_acc");

                entity.Property(e => e.IdTest)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("id_test");

                entity.Property(e => e.Mess)
                    .HasMaxLength(1000)
                    .HasColumnName("mess");

                entity.Property(e => e.Stat).HasColumnName("stat");

                entity.HasOne(d => d.IdAccNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.IdAcc)
                    .HasConstraintName("FK_comment_account");

                entity.HasOne(d => d.IdTestNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.IdTest)
                    .HasConstraintName("FK_comment_test");
            });

            modelBuilder.Entity<Competition>(entity =>
            {
                entity.HasKey(e => e.IdCom)
                    .HasName("PK__competit__D6967171FFDEF73D");

                entity.ToTable("competitions");

                entity.Property(e => e.IdCom)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("id_com");

                entity.Property(e => e.DateEnd)
                    .HasColumnType("datetime")
                    .HasColumnName("date_end");

                entity.Property(e => e.DateStart)
                    .HasColumnType("datetime")
                    .HasColumnName("date_start");

                entity.Property(e => e.Desc)
                    .HasMaxLength(800)
                    .HasColumnName("desc");

                entity.Property(e => e.IdAcc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("id_acc");

                entity.Property(e => e.ImgOfCom)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("img_of_com");

                entity.Property(e => e.NameCom)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name_com");

                entity.Property(e => e.Stat).HasColumnName("stat");

                entity.HasOne(d => d.IdAccNavigation)
                    .WithMany(p => p.Competitions)
                    .HasForeignKey(d => d.IdAcc)
                    .HasConstraintName("FK_competitions_account");
            });

            modelBuilder.Entity<DetailBill>(entity =>
            {
                entity.HasKey(e => new { e.IdBill, e.IdTest })
                    .HasName("PK__detailBi__690DB37148FC3D0F");

                entity.ToTable("detailBill");

                entity.Property(e => e.IdBill)
                    .HasMaxLength(100)
                    .HasColumnName("id_bill");

                entity.Property(e => e.IdTest)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("id_test");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasColumnName("created");

                entity.Property(e => e.PayerEmail)
                    .HasMaxLength(100)
                    .HasColumnName("payer_email");

                entity.Property(e => e.PayerFirstName)
                    .HasMaxLength(20)
                    .HasColumnName("payer_first_name");

                entity.Property(e => e.PayerLastName)
                    .HasMaxLength(20)
                    .HasColumnName("payer_last_name");

                entity.Property(e => e.PayerShippingAddr)
                    .HasMaxLength(200)
                    .HasColumnName("payer_shipping_addr");

                entity.Property(e => e.Payment)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("payment");

                entity.Property(e => e.Total)
                    .HasColumnType("money")
                    .HasColumnName("total");

                entity.HasOne(d => d.IdBillNavigation)
                    .WithMany(p => p.DetailBills)
                    .HasForeignKey(d => d.IdBill)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_detailBill_bill");

                entity.HasOne(d => d.IdTestNavigation)
                    .WithMany(p => p.DetailBills)
                    .HasForeignKey(d => d.IdTest)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_detailBill_test");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.HasKey(e => e.IdFeedback)
                    .HasName("PK__feedback__36BC8630C0EE8B7C");

                entity.ToTable("feedback");

                entity.Property(e => e.IdFeedback)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("id_feedback");

                entity.Property(e => e.Datereply)
                    .HasColumnType("datetime")
                    .HasColumnName("datereply");

                entity.Property(e => e.Datesend)
                    .HasColumnType("datetime")
                    .HasColumnName("datesend");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(100)
                    .HasColumnName("fullname");

                entity.Property(e => e.IdAcc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("id_acc");

                entity.Property(e => e.Mail)
                    .HasMaxLength(100)
                    .HasColumnName("mail");

                entity.Property(e => e.Mess)
                    .HasMaxLength(1000)
                    .HasColumnName("mess");

                entity.Property(e => e.ReplyMail)
                    .HasMaxLength(1000)
                    .HasColumnName("reply_mail");

                entity.Property(e => e.Stat).HasColumnName("stat");

                entity.HasOne(d => d.IdAccNavigation)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.IdAcc)
                    .HasConstraintName("FK_feedback_account");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole)
                    .HasName("PK__roles__3D48441D41E48AF8");

                entity.ToTable("roles");

                entity.Property(e => e.IdRole)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("id_role");

                entity.Property(e => e.Datecreated)
                    .HasColumnType("datetime")
                    .HasColumnName("datecreated");

                entity.Property(e => e.Dateupdated)
                    .HasColumnType("datetime")
                    .HasColumnName("dateupdated");

                entity.Property(e => e.NameRole)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name_role");

                entity.Property(e => e.Stat).HasColumnName("stat");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.HasKey(e => e.IdTest)
                    .HasName("PK__test__C6D3284B53924306");

                entity.ToTable("test");

                entity.Property(e => e.IdTest)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("id_test");

                entity.Property(e => e.Content)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("content");

                entity.Property(e => e.Datecreated)
                    .HasColumnType("datetime")
                    .HasColumnName("datecreated");

                entity.Property(e => e.Dateupdated)
                    .HasColumnType("datetime")
                    .HasColumnName("dateupdated");

                entity.Property(e => e.Desc)
                    .HasMaxLength(800)
                    .HasColumnName("desc");

                entity.Property(e => e.IdAcc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("id_acc");

                entity.Property(e => e.IdCom)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("id_com");

                entity.Property(e => e.IdComment)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("id_comment");

                entity.Property(e => e.ImgOfTest)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("img_of_test");

                entity.Property(e => e.NameTest)
                    .HasMaxLength(200)
                    .HasColumnName("name_test");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.Property(e => e.Stat).HasColumnName("stat");

                entity.HasOne(d => d.IdAccNavigation)
                    .WithMany(p => p.Tests)
                    .HasForeignKey(d => d.IdAcc)
                    .HasConstraintName("FK_test_account");
            });

            modelBuilder.Entity<TestCore>(entity =>
            {
                entity.HasKey(e => e.IdCom)
                    .HasName("PK__test_cor__D696717162BD77AF");

                entity.ToTable("test_core");

                entity.HasIndex(e => e.IdTest, "test_core_test")
                    .IsUnique();

                entity.Property(e => e.IdCom)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("id_com");

                entity.Property(e => e.DateUpdate)
                    .HasColumnType("datetime")
                    .HasColumnName("date_update");

                entity.Property(e => e.Desc)
                    .HasMaxLength(800)
                    .HasColumnName("desc");

                entity.Property(e => e.GradingDate)
                    .HasColumnType("datetime")
                    .HasColumnName("grading_date");

                entity.Property(e => e.IdTest)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("id_test");

                entity.Property(e => e.Scores).HasColumnName("scores");

                entity.Property(e => e.Stat).HasColumnName("stat");

                entity.HasOne(d => d.IdComNavigation)
                    .WithOne(p => p.TestCore)
                    .HasForeignKey<TestCore>(d => d.IdCom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_test_core_competitions");

                entity.HasOne(d => d.IdTestNavigation)
                    .WithOne(p => p.TestCore)
                    .HasForeignKey<TestCore>(d => d.IdTest)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__test_core__id_te__2F10007B");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => new { e.IdRole, e.IdAcc })
                    .HasName("PK__user_rol__6BF6CB1BBE409F31");

                entity.ToTable("user_role");

                entity.Property(e => e.IdRole)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("id_role");

                entity.Property(e => e.IdAcc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("id_acc");

                entity.Property(e => e.Datecreated)
                    .HasColumnType("datetime")
                    .HasColumnName("datecreated");

                entity.Property(e => e.Dateupdated)
                    .HasColumnType("datetime")
                    .HasColumnName("dateupdated");

                entity.HasOne(d => d.IdAccNavigation)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.IdAcc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_role_account");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_role_role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
