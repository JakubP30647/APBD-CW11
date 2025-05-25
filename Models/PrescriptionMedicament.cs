using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_CW11.Models;

[Table("PrescriptionMedicaments")]
public class PrescriptionMedicament
{
    [ForeignKey(nameof(Medicament))] public int IdMedicament { get; set; }
    public Medicament Medicament { get; set; }
    [ForeignKey(nameof(Prescription))] public int IdPrescription { get; set; }
    public Prescription Prescription { get; set; }

    public int Dose { get; set; }
    public string Details { get; set; }
}