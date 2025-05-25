using APBD_CW11.Models;
using APBD_CW11.Models.DTOs;

namespace APBD_CW11.Data;

using Microsoft.EntityFrameworkCore;

public class DataBaseContext : DbContext
{
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }

    
    protected DataBaseContext()
    {
    }
    
    public DataBaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Patient>(a =>
        {
            a.ToTable("Patient");

            a.HasKey(e => e.IdPatient);
            a.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            a.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsRequired();
            
            a.Property(e => e.Birthdate)
                .IsRequired();

            a.HasMany(p => p.Prescriptions)
                .WithOne(p => p.Patient)
                .HasForeignKey(pr => pr.IdPatient);
            
        });


        modelBuilder.Entity<Doctor> (a =>
        {
            
            a.ToTable("Doctor");
            a.HasKey(e => e.IdDoctor);
            a.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsRequired();
            
            a.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsRequired();
            
            a.Property(e => e.Email)
                .HasMaxLength(100)
                .IsRequired();

            a.HasMany(d => d.Prescriptions)
                .WithOne(pr => pr.Doctor)
                .HasForeignKey(pr => pr.IdDoctor);

            

        });
        
        modelBuilder.Entity<Medicament>(a =>
        {
            a.ToTable("Medicament");
            a.HasKey(e => e.IdMedicament);
            a.Property(e => e.Name)
                .HasMaxLength(100)
                .IsRequired();
            a.Property(e => e.Description)
                .HasMaxLength(100)
                .IsRequired();
            a.Property(e => e.Type)
                .HasMaxLength(100)
                .IsRequired();
        });

        modelBuilder.Entity<Prescription>(a =>
        {
            a.ToTable("Prescription");
            a.HasKey(e => e.IdPrescription);
            
            a.Property(e => e.Date)
                .IsRequired();
           
            a.Property(e => e.DueDate)
                .IsRequired();

            a.HasOne(p => p.Patient)
                .WithMany(pa => pa.Prescriptions)
                .HasForeignKey(p => p.IdPatient);

            a.HasOne(p => p.Doctor)
                .WithMany(d => d.Prescriptions)
                .HasForeignKey(p => p.IdDoctor);
        });
        
        modelBuilder.Entity<PrescriptionMedicament>(a =>
        {
            a.HasKey(e => new { e.IdMedicament, e.IdPrescription });

            a.Property(e => e.Dose);
            a.Property(e => e.Details)
                .HasMaxLength(100)
                .IsRequired();

            a.HasOne(e => e.Medicament)
                .WithMany(m => m.PrescriptionMedicaments)
                .HasForeignKey(e => e.IdMedicament);
            
            a.HasOne(e => e.Prescription)
                .WithMany(p => p.PrescriptionMedicaments)
                .HasForeignKey(e => e.IdPrescription);
        });


    }
}