using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace QuanLyChiTieu04_NguyenBaoLong04.DAL.Models
{
    public partial class QuanLyChiTieuContext : DbContext
    {
        public QuanLyChiTieuContext()
        {
        }

        public QuanLyChiTieuContext(DbContextOptions<QuanLyChiTieuContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<GroupsUser> GroupsUsers { get; set; }
        public virtual DbSet<IncomeAndExpense> IncomeAndExpenses { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=QuanLyChiTieu;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GroupsUser>(entity =>
            {
                entity.ToTable("Groups_Users");

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsGroupLeader).HasDefaultValueSql("((0))");

                entity.Property(e => e.JoinDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupsUsers)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Groups_Us__Group__30F848ED");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.GroupsUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Groups_Us__UserI__31EC6D26");
            });

            modelBuilder.Entity<IncomeAndExpense>(entity =>
            {
                entity.ToTable("IncomeAndExpense");

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(12, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Approved).HasDefaultValueSql("((1))");

                entity.Property(e => e.Confirmed).HasDefaultValueSql("((1))");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Detail).HasColumnType("text");

                entity.Property(e => e.IsIncome).HasDefaultValueSql("((1))");

                entity.Property(e => e.Reason)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.IncomeAndExpenses)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__IncomeAnd__Group__3E52440B");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.IncomeAndExpenses)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__IncomeAnd__UserI__3F466844");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Username, "UQ__Users__536C85E436898652")
                    .IsUnique();

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
