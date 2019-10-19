using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TheReminder.Models
{
    public partial class thereminderContext : DbContext
    {
        public thereminderContext()
        {
        }

        public thereminderContext(DbContextOptions<thereminderContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Task> Task { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=thereminder.database.windows.net;Initial Catalog=thereminder;User ID=comp2084;Password=Abcd1234@");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.StudentNumber).ValueGeneratedNever();

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.StudentId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.Property(e => e.CompleteStatus).IsUnicode(false);

                entity.Property(e => e.TaskName).IsUnicode(false);

                entity.HasOne(d => d.StudentNumberNavigation)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.StudentNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Task_StudentNumber");
            });
        }
    }
}
