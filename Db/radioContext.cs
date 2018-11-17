using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace radioapi.Db
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
        public virtual DbSet<FileType> FileType { get; set; }
        public virtual DbSet<Program> Program { get; set; }
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

                entity.HasIndex(e => e.FileTypeId)
                    .HasName("FK_file_type_id");

                entity.HasIndex(e => e.ProgramId)
                    .HasName("program_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FileTypeId)
                    .HasColumnName("file_type_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasColumnName("path")
                    .IsUnicode(false);

                entity.Property(e => e.ProgramId)
                    .HasColumnName("program_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.FileType)
                    .WithMany(p => p.File)
                    .HasForeignKey(d => d.FileTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_file_type_id");
            });

            modelBuilder.Entity<FileType>(entity =>
            {
                entity.ToTable("file_type", "radio");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .IsUnicode(false);

                entity.Property(e => e.Ext)
                    .IsRequired()
                    .HasColumnName("ext")
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Program>(entity =>
            {
                entity.ToTable("program", "radio");

                entity.HasIndex(e => new { e.RadioId, e.Timestamp })
                    .HasName("UI_program_radio_timestamp")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasColumnName("author")
                    .IsUnicode(false);

                entity.Property(e => e.RadioId)
                    .HasColumnName("radio_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Timestamp).HasColumnName("timestamp");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .IsUnicode(false);

                entity.HasOne(d => d.Radio)
                    .WithMany(p => p.Program)
                    .HasForeignKey(d => d.RadioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_program_radio_id");
            });

            modelBuilder.Entity<Radio>(entity =>
            {
                entity.ToTable("radio", "radio");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .IsUnicode(false);

                entity.Property(e => e.StreamUrl)
                    .IsRequired()
                    .HasColumnName("stream_url")
                    .IsUnicode(false);
            });
        }
    }
}
