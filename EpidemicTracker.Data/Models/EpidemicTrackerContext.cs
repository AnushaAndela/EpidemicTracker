using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace EpidemicTracker.Data.Models
{
    public partial class EpidemicTrackerContext : DbContext
    {
        public EpidemicTrackerContext()
        {
        }

        public EpidemicTrackerContext(DbContextOptions<EpidemicTrackerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Disease> Disease { get; set; }
        public virtual DbSet<DiseaseType> DiseaseType { get; set; }
        public virtual DbSet<Hospital> Hospital { get; set; }
        public virtual DbSet<Occupation> Occupation { get; set; }
        public virtual DbSet<OccupationType> OccupationType { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<Treatment> Treatment { get; set; }

       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot config = builder.Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.AddressType)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Hno)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PatientId).HasColumnName("PatientID");

                entity.Property(e => e.Pincode).HasColumnName("PINCODE");

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("date");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__Address__Patient__36B12243");
            });

            modelBuilder.Entity<Disease>(entity =>
            {
                entity.Property(e => e.DiseaseId).HasColumnName("DiseaseID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.DiseaseTypeId).HasColumnName("DiseaseTypeID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("date");

                entity.HasOne(d => d.DiseaseType)
                    .WithMany(p => p.Disease)
                    .HasForeignKey(d => d.DiseaseTypeId)
                    .HasConstraintName("FK__Disease__Disease__2E1BDC42");
            });

            modelBuilder.Entity<DiseaseType>(entity =>
            {
                entity.Property(e => e.DiseaseTypeId).HasColumnName("DiseaseTypeID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.TypeOfDisease)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("date");
            });

            modelBuilder.Entity<Hospital>(entity =>
            {
                entity.Property(e => e.HospitalId).HasColumnName("HospitalID");

                entity.Property(e => e.Area)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StreetNo)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("date");
            });

            modelBuilder.Entity<Occupation>(entity =>
            {
                entity.Property(e => e.OccupationId).HasColumnName("OccupationID");

                entity.Property(e => e.Area)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PatientId).HasColumnName("PatientID");

                entity.Property(e => e.State)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StreetNo)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("date");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Occupation)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__Occupatio__Patie__398D8EEE");
            });

            modelBuilder.Entity<OccupationType>(entity =>
            {
                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.OccupationId).HasColumnName("OccupationID");

                entity.Property(e => e.Type)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("date");

                entity.HasOne(d => d.Occupation)
                    .WithMany(p => p.OccupationType)
                    .HasForeignKey(d => d.OccupationId)
                    .HasConstraintName("FK__Occupatio__Occup__3C69FB99");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasIndex(e => e.AadharId)
                    .HasName("UQ__Patient__40DD97BEAA6CC14A")
                    .IsUnique();

                entity.Property(e => e.PatientId).HasColumnName("PatientID");

                entity.Property(e => e.AadharId).HasColumnName("AadharID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("date");
                
                    
            });

            modelBuilder.Entity<Treatment>(entity =>
            {
                entity.Property(e => e.TreatmentId).HasColumnName("TreatmentID");

                entity.Property(e => e.AdmittedDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.DiseaseId).HasColumnName("DiseaseID");

                entity.Property(e => e.HospitalId).HasColumnName("HospitalID");

                entity.Property(e => e.Isfatility).HasColumnName("ISFatility");

                entity.Property(e => e.PatientId).HasColumnName("PatientID");

                entity.Property(e => e.PercentageCure).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.RelievingDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("date");

                entity.HasOne(d => d.Disease)
                    .WithMany(p => p.Treatment)
                    .HasForeignKey(d => d.DiseaseId)
                    .HasConstraintName("FK__Treatment__Disea__31EC6D26");

                entity.HasOne(d => d.Hospital)
                    .WithMany(p => p.Treatment)
                    .HasForeignKey(d => d.HospitalId)
                    .HasConstraintName("FK__Treatment__Hospi__32E0915F");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Treatment)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__Treatment__Patie__30F848ED");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
