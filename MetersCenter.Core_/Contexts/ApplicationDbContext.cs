using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetersCenter.Data;
using Microsoft.EntityFrameworkCore;

namespace MetersCenter.Core_.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MeterProviders>().HasData(
                new MeterProviders { Id = 1, Name = "ElSewedy" },
                new MeterProviders { Id = 2, Name = "Elster Group" },
                new MeterProviders { Id = 3, Name = "Itron" },
                new MeterProviders { Id = 4, Name = "Sappel" },
                new MeterProviders { Id = 5, Name = "Arad Group" },
                new MeterProviders { Id = 6, Name = "Zenner" },
                new MeterProviders { Id = 7, Name = "Kamstrup" },
                new MeterProviders { Id = 8, Name = "Actaris" },
                new MeterProviders { Id = 9, Name = "Siemens" },
                new MeterProviders { Id = 10, Name = "Neptune Technology Group" }
                );

            modelBuilder.Entity<MeterData>()
                        .HasOne(s => s.Supplies)
                        .WithMany(m=> m.MeterData)
                        .HasForeignKey(fk=> fk.SuppliesId);

            modelBuilder.Entity<MeterProviders>()
                        .HasMany(s => s.Supplies)
                        .WithOne(m => m.MeterProviders)
                        .HasForeignKey(fk => fk.MeterProviderId);


        }
        public DbSet<MeterData> MeterData { get; set; }
        public DbSet<MeterProviders> MeterProviders { get; set; }
        public DbSet<Supplies> Supplies { get; set; }

    }

}
