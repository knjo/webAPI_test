using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TodoApi.Models
{
    public partial class backgroundContext : DbContext
    {
        public backgroundContext()
        {
        }

        public backgroundContext(DbContextOptions<backgroundContext> options)  : base(options)
        {
        }

        public virtual DbSet<Feature> Features { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=background-server.database.windows.net;Initial Catalog=background;Persist Security Info=True;User ID=azureuser;Password=User1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Feature>(entity =>
            {
                entity.ToTable("FEATURE");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Biometrics).HasColumnName("biometrics");

                entity.Property(e => e.Day).HasColumnName("day");

                entity.Property(e => e.Endtime)
                    .HasMaxLength(128)
                    .HasColumnName("endtime");

                entity.Property(e => e.Month).HasColumnName("month");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("name");

                entity.Property(e => e.Single).HasColumnName("single");

                entity.Property(e => e.Starttime)
                    .HasMaxLength(128)
                    .HasColumnName("starttime");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("status");

                entity.Property(e => e.Verificationcode).HasColumnName("verificationcode");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
