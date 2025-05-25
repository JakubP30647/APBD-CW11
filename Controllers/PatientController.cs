using APBD_CW11.Exceptions;
using APBD_CW11.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_CW11.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientController : ControllerBase
{
    readonly IPatientService _patientService;
    

    public PatientController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetPatients(int id)
    {
        try
        {
            return Ok(await _patientService.GetPatient(id));
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}