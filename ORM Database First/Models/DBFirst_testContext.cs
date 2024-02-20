using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ORM_Database_First.Models
{
    public partial class DBFirst_testContext : DbContext
    {
        public DBFirst_testContext()
        {
        }

        public DBFirst_testContext(DbContextOptions<DBFirst_testContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<DepartmentEmployee> DepartmentEmployees { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Manager> Managers { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=dbCon");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<DepartmentEmployee>(entity =>
            {
                entity.HasKey(e => new { e.DepartmentId, e.EmployeeId, e.ProjectId })
                    .HasName("PK__Departme__44DC85A2A87AF7B7");

                entity.ToTable("DepartmentEmployee");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.DepartmentEmployees)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Departmen__Depar__2A164134");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.DepartmentEmployees)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Departmen__Emplo__2B0A656D");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.DepartmentEmployees)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Departmen__Proje__2BFE89A6");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employees");

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("fk_emp_DepartmentId");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("fk_emp_ProjectId");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.Property(e => e.ManagerId).ValueGeneratedNever();

                entity.Property(e => e.ManagerName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.ManagerNavigation)
                    .WithOne(p => p.Manager)
                    .HasForeignKey<Manager>(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_man_ManagerId");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.ProjectName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("projectName");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("fk_pro_DepartmentId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
