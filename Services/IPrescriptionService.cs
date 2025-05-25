using APBD_CW11.Models.DTOs;

namespace APBD_CW11.Services;

public interface IPrescriptionService
{
    Task AddPrescription(PrescriptionForRequestDTO prescription);
}