using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PracticeProject.Models
{
    public partial class sdirectdbContext : DbContext
    {
        public sdirectdbContext()
        {
        }

        public sdirectdbContext(DbContextOptions<sdirectdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmployeeJuly3> EmployeeJuly3s { get; set; } = null!;
        public virtual DbSet<MyLoginTable> MyLoginTables { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=192.168.0.240;Database=sdirectdb;User ID=sdirectdb;Password=sdirectdb;Trusted_Connection=False;MultipleActiveResultSets=true;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeJuly3>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__Employee__AF2DBB99ECC877DF");

                entity.ToTable("EmployeeJuly3");

                entity.Property(e => e.City)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("date");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.EmpEmail)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EmpName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<MyLoginTable>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__MyLoginT__1788CC4C749218B7");

                entity.ToTable("MyLoginTable");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
