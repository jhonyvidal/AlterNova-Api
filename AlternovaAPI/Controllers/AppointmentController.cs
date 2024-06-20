
using AlternovaBusiness.DTO;
using AlternovaBusiness.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AlternovaAPI.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class AppointmentController : ControllerBase
{

    private readonly IAppointmentService _AppointmentService;

    public AppointmentController(IAppointmentService service)
    {
        _AppointmentService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            var carDetails = _AppointmentService.Get();
            return Ok(carDetails);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while retrieving", ex);
        }
    }

    [HttpPost()]
    public IActionResult Post([FromBody] AppointmentDTO request)
    {
        try
        {
            var result = _AppointmentService.Post(request);
            return Ok(result); 
        }
        catch (Exception ex)
        {
            return StatusCode(500,  ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
    //    var Appointment = _AppointmentService.Get(id);
            
    //     if(Appointment == null)
    //         return NotFound();
        try{
            _AppointmentService.Delete(id);
        }catch(Exception ex){
            return BadRequest(ex.Message);
        }
        return Ok();
    }
    
}
