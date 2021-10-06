using System;
using Login.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Login.Context
{
    public partial class usersContext : DbContext
    {
        public usersContext()
        {
        }

        public usersContext(DbContextOptions<usersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Usertable> Usertables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("Server=127.0.0.1;Port=3306;Database=users;Uid=admin;Pwd=bartsql666;SslMode=Preferred;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usertable>(entity =>
            {
                entity.ToTable("usertable");

                entity.HasIndex(e => e.Id, "ID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<Login.Models.SignUpViewModel> SignUpViewModel { get; set; }
    }
}
