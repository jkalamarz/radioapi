using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace radioapi.db
{
    public partial class radioContext : DbContext
    {
        public radioContext()
        {
        }

        public radioContext(DbContextOptions<radioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<File> File { get; set; }
        public virtual DbSet<Radio> Radio { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=radioapi;password=joanna5;database=radio");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<File>(entity =>
            {
                entity.ToTable("file", "radio");

                entity.HasIndex(e => e.RadioId)
                    .HasName("FK_file_radio_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedOn).HasColumnName("created_on");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PathAac)
                    .HasColumnName("path_aac")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PathMp3)
                    .HasColumnName("path_mp3")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PathNoads)
                    .HasColumnName("path_noads")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RadioId)
                    .HasColumnName("radio_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Radio)
                    .WithMany(p => p.InverseRadio)
                    .HasForeignKey(d => d.RadioId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("file_ibfk_1");
            });

            modelBuilder.Entity<Radio>(entity =>
            {
                entity.ToTable("radio", "radio");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StreamUrl)
                    .HasColumnName("stream_url")
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });
        }
    }
}
