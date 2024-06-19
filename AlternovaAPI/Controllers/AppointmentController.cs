using Appointment.Core.Interface;
using Microsoft.AspNetCore.Mvc;
// using Wheelzy.Core.Services;

namespace AlternovaAPI.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class AppointmentController : ControllerBase
{

    private readonly IAppointmentService _CarService;

    public AppointmentController(IAppointmentService service)
    {
        _CarService = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetCarDetails()
    {
        try
        {
            var carDetails = await _CarService.GetCarDetailsAsync();
            return Ok(carDetails);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while retrieving car details", ex);
        }
    }
    
}
