using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace api.Models
{
    public partial class SRAContext : DbContext
    {
        public SRAContext()
        {
        }

        public SRAContext(DbContextOptions<SRAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<Issue> Issue { get; set; }
        public virtual DbSet<Students> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=192.168.99.100;Database=StudentRep;User=sa;Password=yourStrong(*)Password");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Department)
                    .IsRequired()
                    .HasColumnName("department")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasColumnName("emailAddress")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasColumnName("role")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Feedback1)
                    .IsRequired()
                    .HasColumnName("feedback")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Following)
                    .HasColumnName("following")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Issue)
                    .IsRequired()
                    .HasColumnName("issue")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Votes).HasColumnName("votes");
            });

            modelBuilder.Entity<Issue>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .IsRequired()
                    .HasColumnName("date")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DownVotes).HasColumnName("downVotes");

                entity.Property(e => e.FlaggedInappropiate).HasColumnName("flaggedInappropiate");

                entity.Property(e => e.Priority).HasColumnName("priority");

                entity.Property(e => e.Show).HasColumnName("show");

                entity.Property(e => e.StatusDescription)
                    .HasColumnName("statusDescription")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpVotes).HasColumnName("upVotes");
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.StudentNumber);

                entity.Property(e => e.StudentNumber)
                    .HasColumnName("studentNumber")
                    .ValueGeneratedNever();

                entity.Property(e => e.IsStudentRep).HasColumnName("isStudentRep");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
