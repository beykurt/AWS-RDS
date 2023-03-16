using Microsoft.EntityFrameworkCore;
using RDS.Libs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Libs.Data
{
    public partial class RDSContext : DbContext
    {
        public RDSContext(DbContextOptions<RDSContext> options) : base(options)
        {
        }

        public virtual DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.IdPerson).HasName("PRIMARY");

                entity
                    .ToTable("person")
                    .HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Name).HasColumnName("Name").HasMaxLength(45);
                entity.Property(e => e.Surname).HasColumnName("Surname").HasMaxLength(45);
                entity.Property(e => e.Mail).HasColumnName("Mail").HasMaxLength(45);
                entity.Property(e => e.Phone).HasColumnName("Phone").HasMaxLength(45);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
