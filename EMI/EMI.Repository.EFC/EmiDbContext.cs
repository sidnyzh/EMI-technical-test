using EMI.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI.Repository.EFC
{
    public partial class EmiDbContext : DbContext
    {
        public EmiDbContext()
        {
        }

        public EmiDbContext(DbContextOptions<EmiDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<EmployeeProject> EmployeeProjects { get; set; }

        public virtual DbSet<Position> Positions { get; set; }

        public virtual DbSet<PositionHistory> PositionHistories { get; set; }

        public virtual DbSet<Project> Projects { get; set; }

        public virtual DbSet<RequestLog> RequestLogs { get; set; }

        public virtual DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DepartmentId).HasName("PK_Department");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Salary).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.CurrentPositionNavigation).WithMany(p => p.Employees)
                    .HasForeignKey(d => d.CurrentPosition)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_Positions");

                entity.HasOne(d => d.DepartmentNavigation).WithMany(p => p.Employees)
                    .HasForeignKey(d => d.Department)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_Departments");
            });

            modelBuilder.Entity<EmployeeProject>(entity =>
            {
                entity.HasOne(d => d.EmployeeNavigation).WithMany(p => p.EmployeeProjects)
                    .HasForeignKey(d => d.Employee)
                    .HasConstraintName("FK_EmployeeProjects_Employees");

                entity.HasOne(d => d.ProjectNavigation).WithMany(p => p.EmployeeProjects)
                    .HasForeignKey(d => d.Project)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeProjects_Projects");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.Property(e => e.PositionId)
                    .ValueGeneratedNever()
                    .HasColumnName("positionId");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PositionHistory>(entity =>
            {
                entity.ToTable("PositionHistory");

                entity.Property(e => e.PositionHistoryId).HasColumnName("PositionHistoryID");
                entity.Property(e => e.EndDate).HasColumnType("datetime");
                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.EmployeeNavigation).WithMany(p => p.PositionHistories)
                    .HasForeignKey(d => d.Employee)
                    .HasConstraintName("FK_PositionHistory_Employees");

                entity.HasOne(d => d.PositionNavigation).WithMany(p => p.PositionHistories)
                    .HasForeignKey(d => d.Position)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PositionHistory_Positions");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
                entity.Property(e => e.EndDate).HasColumnType("datetime");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.DepartmentNavigation).WithMany(p => p.Projects)
                    .HasForeignKey(d => d.Department)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Projects_Departments");
            });

            modelBuilder.Entity<RequestLog>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__RequestL__3214EC07FEF0E059");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Headers).HasColumnType("text");
                entity.Property(e => e.Identifier)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.QueryString)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.RequestBody).HasColumnType("text");
                entity.Property(e => e.RequestMethod)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.RequestPath)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.Timestamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ_Email").IsUnique();

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Password)
                    .HasMaxLength(70)
                    .IsUnicode(false);
                entity.Property(e => e.Role)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
