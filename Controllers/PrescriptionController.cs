using APBD_CW11.Exceptions;
using APBD_CW11.Models.DTOs;
using APBD_CW11.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_CW11.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PrescriptionController : ControllerBase
{
    readonly IPrescriptionService _prescriptionService;

    public PrescriptionController(IPrescriptionService prescriptionService)
    {
        _prescriptionService = prescriptionService;
    }

    [HttpPost]
    public async Task<IActionResult> AddPrescription(PrescriptionForRequestDTO prescription)
    {
        try
        {
            await _prescriptionService.AddPrescription(prescription);
            return CreatedAtAction(nameof(AddPrescription),prescription);
        }catch (NotFoundException e)
        {
            return NotFound(e.Message);
            
        }catch (BadReqException e)
        {
            return BadRequest(e.Message);
        }
        
    }
}