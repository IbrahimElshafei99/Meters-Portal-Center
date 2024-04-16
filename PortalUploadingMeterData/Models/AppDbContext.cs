using Microsoft.EntityFrameworkCore;
using System.Data;

namespace PortalUploadingMeterData.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MeterData>().HasAlternateKey(x => new {x.MeterSerial, x.CompanyId});

            modelBuilder.Entity<MeterData>().HasIndex(x => new {x.CompanyId, x.MeterPublicKey}).IsUnique();

            modelBuilder.Entity<MeterData>()
                        .HasOne(x => x.MeterInspection)
                        .WithOne(x => x.MeterData)
                        .HasForeignKey<Inspection>(x=> x.MeterId)
                        .IsRequired();

            modelBuilder.Entity<Company>()
                        .HasMany(m => m.MeterData)
                        .WithOne(c => c.Company)
                        .HasForeignKey(c => c.CompanyId);

            modelBuilder.Entity<MasterRecord>()
                        .HasMany(m => m.MeterData)
                        .WithOne(c => c.MasterRecord)
                        .HasForeignKey(c => c.MasterRecordId);

            modelBuilder.Entity<Company>().HasData(
                new Company { Id = 1, Name = "ElSewedy" },
                new Company { Id = 2, Name = "Elster Group" },
                new Company { Id = 3, Name = "Itron" },
                new Company { Id = 4, Name = "Sappel" },
                new Company { Id = 5, Name = "Arad Group" },
                new Company { Id = 6, Name = "Zenner" },
                new Company { Id = 7, Name = "Kamstrup" },
                new Company { Id = 8, Name = "Actaris" },
                new Company { Id = 9, Name = "Siemens" },
                new Company { Id = 10, Name = "Neptune Technology Group" }
                );
        }
        public DbSet<MeterData> MeterData { get; set; }
        public DbSet<Company> Company {  get; set; }
        public DbSet<Inspection> Inspection { get; set; }
        public DbSet<MasterRecord> MasterRecord { get; set; }

    }
}
