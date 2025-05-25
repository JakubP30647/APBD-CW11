using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using APBD_CW11.Models.DTOs;

namespace APBD_CW11.Models;

[Table("Prescription")]
public class Prescription
{
    
    [Key]
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    [ForeignKey(nameof(Patient))]
    public int IdPatient { get; set; }
    public Patient Patient { get; set; }
    
    [ForeignKey(nameof(Doctor))]
    public int IdDoctor { get; set; }
    public Doctor Doctor { get; set; }
    
    public ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    
}