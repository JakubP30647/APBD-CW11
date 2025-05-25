namespace APBD_CW11.Models.DTOs;

public class PrescriptionForRequestDTO
{
    public PatientForRequestDTO Patient { get; set; }
    public ICollection<MedicamentForRequestDTO> Medicaments { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public int IdDoctor { get; set; }
    
}
public class PatientForRequestDTO
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }
}
public class MedicamentForRequestDTO
{
    public int IdMedicament { get; set; }
    public int Dose { get; set; }
    public string Description { get; set; }
}