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

        public virtual DbSet<Feedback> Feedback { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=StudentRep;User=sa;Password=yourStrong(*)Password;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Feedback1)
                    .IsRequired()
                    .HasColumnName("feedback")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Issue)
                    .IsRequired()
                    .HasColumnName("issue")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Votes).HasColumnName("votes");
            });
        }
    }
}
