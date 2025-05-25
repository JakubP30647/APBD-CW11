using APBD_CW11.Models.DTOs;

namespace APBD_CW11.Services;

public interface IPatientService
{
    Task<PatientForReturnDTO> GetPatient(int id);
    
}