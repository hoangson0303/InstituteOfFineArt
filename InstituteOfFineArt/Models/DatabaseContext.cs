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
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<TestCore> TestCores { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.IdAcc)
                    .HasName("PK__account__6BE8F064D3E596BE");

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
                entity.HasKey(e => e.IdOrder)
                    .HasName("PK__bill__DD5B8F3F0B684BC2");

                entity.ToTable("bill");

                entity.Property(e => e.IdOrder)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("id_order");

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
                    .HasName("PK__comment__7E14AC85F2AB4B79");

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
                    .HasName("PK__competit__D69671711197F5D4");

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
                    .HasMaxLength(1)
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

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.HasKey(e => e.IdFeedback)
                    .HasName("PK__feedback__36BC8630CCF3C1D9");

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

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.IdOrder, e.IdTest })
                    .HasName("PK__orderDet__7136BDBBA81A8199");

                entity.ToTable("orderDetail");

                entity.Property(e => e.IdOrder)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("id_order");

                entity.Property(e => e.IdTest)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("id_test");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasColumnName("created");

                entity.Property(e => e.NamePay)
                    .HasMaxLength(100)
                    .HasColumnName("name_pay");

                entity.Property(e => e.Payment)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("payment");

                entity.Property(e => e.Total)
                    .HasColumnType("money")
                    .HasColumnName("total");

                entity.HasOne(d => d.IdOrderNavigation)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.IdOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_orderDetail_bill");

                entity.HasOne(d => d.IdTestNavigation)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.IdTest)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_orderDetail_test");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole)
                    .HasName("PK__roles__3D48441DEFBDEB29");

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
                    .HasName("PK__test__C6D3284B31C47B4B");

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
                    .HasMaxLength(1)
                    .HasColumnName("desc");

                entity.Property(e => e.IdAcc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("id_acc");

                entity.Property(e => e.IdComment)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("id_comment");

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
                entity.HasKey(e => new { e.IdTest, e.IdCom })
                    .HasName("PK__test_cor__CBBA4F5C2B3121F0");

                entity.ToTable("test_core");

                entity.Property(e => e.IdTest)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("id_test");

                entity.Property(e => e.IdCom)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("id_com");

                entity.Property(e => e.DateUpdate)
                    .HasColumnType("datetime")
                    .HasColumnName("date_update");

                entity.Property(e => e.Desc)
                    .HasMaxLength(1)
                    .HasColumnName("desc");

                entity.Property(e => e.GradingDate)
                    .HasColumnType("datetime")
                    .HasColumnName("grading_date");

                entity.Property(e => e.Scores).HasColumnName("scores");

                entity.Property(e => e.Stat).HasColumnName("stat");

                entity.HasOne(d => d.IdComNavigation)
                    .WithMany(p => p.TestCores)
                    .HasForeignKey(d => d.IdCom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_test_core_competitions");

                entity.HasOne(d => d.IdTestNavigation)
                    .WithMany(p => p.TestCores)
                    .HasForeignKey(d => d.IdTest)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_test_core_test");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => new { e.IdRole, e.IdAcc })
                    .HasName("PK__user_rol__6BF6CB1B01A2E4AB");

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
