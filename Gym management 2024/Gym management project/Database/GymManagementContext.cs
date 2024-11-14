using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Gym_management_project.gym_management;

public partial class GymManagementContext : DbContext
{
    public GymManagementContext()
    {
    }

    public GymManagementContext(DbContextOptions<GymManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Classattendance> Classattendances { get; set; }

    public virtual DbSet<Classschedule> Classschedules { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Customerparameter> Customerparameters { get; set; }

    public virtual DbSet<Customertrainer> Customertrainers { get; set; }

    public virtual DbSet<Membership> Memberships { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Trainer> Trainers { get; set; }

    public virtual DbSet<Visit> Visits { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=gym_management;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Classid).HasName("PRIMARY");

            entity.ToTable("classes");

            entity.Property(e => e.Classid)
                .HasColumnType("int(11)")
                .HasColumnName("classid");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Classattendance>(entity =>
        {
            entity.HasKey(e => e.Attendanceid).HasName("PRIMARY");

            entity.ToTable("classattendances");

            entity.HasIndex(e => e.Scheduleid, "FK_ClassAttendances_ClassSchedules");

            entity.Property(e => e.Attendanceid)
                .HasColumnType("int(11)")
                .HasColumnName("attendanceid");
            entity.Property(e => e.Attended).HasColumnName("attended");
            entity.Property(e => e.Customerid)
                .HasColumnType("int(11)")
                .HasColumnName("customerid");
            entity.Property(e => e.Registered).HasColumnName("registered");
            entity.Property(e => e.Scheduleid)
                .HasColumnType("int(11)")
                .HasColumnName("scheduleid");

            entity.HasOne(d => d.Schedule).WithMany(p => p.Classattendances)
                .HasForeignKey(d => d.Scheduleid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClassAttendances_ClassSchedules");
        });

        modelBuilder.Entity<Classschedule>(entity =>
        {
            entity.HasKey(e => e.Scheduleid).HasName("PRIMARY");

            entity.ToTable("classschedules");

            entity.Property(e => e.Scheduleid)
                .HasColumnType("int(11)")
                .HasColumnName("scheduleid");
            entity.Property(e => e.Classid)
                .HasColumnType("int(11)")
                .HasColumnName("classid");
            entity.Property(e => e.Ends).HasColumnName("ends");
            entity.Property(e => e.Starts).HasColumnName("starts");
            entity.Property(e => e.Trainerid)
                .HasColumnType("int(11)")
                .HasColumnName("trainerid");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PRIMARY");

            entity.ToTable("customers");

            entity.Property(e => e.CustomerId)
                .HasColumnType("int(11)")
                .HasColumnName("customerID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .HasColumnName("lastname");
            entity.Property(e => e.Phone)
                .HasMaxLength(24)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Customerparameter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("customerparameters");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Customerid)
                .HasColumnType("int(11)")
                .HasColumnName("customerid");
            entity.Property(e => e.Notificationlimit)
                .HasColumnType("int(11)")
                .HasColumnName("notificationlimit");
        });

        modelBuilder.Entity<Customertrainer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("customertrainers");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Attended)
                .HasColumnType("datetime")
                .HasColumnName("attended");
            entity.Property(e => e.Customerid)
                .HasColumnType("int(11)")
                .HasColumnName("customerid");
            entity.Property(e => e.Registered).HasColumnName("registered");
            entity.Property(e => e.Trainerid)
                .HasColumnType("int(11)")
                .HasColumnName("trainerid");
        });

        modelBuilder.Entity<Membership>(entity =>
        {
            entity.HasKey(e => e.Membershipid).HasName("PRIMARY");

            entity.ToTable("memberships");

            entity.Property(e => e.Membershipid)
                .HasColumnType("int(11)")
                .HasColumnName("membershipid");
            entity.Property(e => e.Customerid)
                .HasColumnType("int(11)")
                .HasColumnName("customerid");
            entity.Property(e => e.Enddate).HasColumnName("enddate");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Productid)
                .HasColumnType("int(11)")
                .HasColumnName("productid");
            entity.Property(e => e.Startdate).HasColumnName("startdate");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PRIMARY");

            entity.ToTable("products");

            entity.Property(e => e.ProductId)
                .HasColumnType("int(11)")
                .HasColumnName("productID");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Trainer>(entity =>
        {
            entity.HasKey(e => e.Trainerid).HasName("PRIMARY");

            entity.ToTable("trainers");

            entity.Property(e => e.Trainerid)
                .HasColumnType("int(11)")
                .HasColumnName("trainerid");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Visit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("visits");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
