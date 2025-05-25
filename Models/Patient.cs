using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_CW11.Models.DTOs;

[Table("Patient")]
public class Patient
{
    
    [Key]
    public int IdPatient { get; set; }
    
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }
    
    public ICollection<Prescription> Prescriptions { get; set; } 
    
}