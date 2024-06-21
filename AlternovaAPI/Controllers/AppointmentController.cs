
using AlternovaBusiness.DTO;
using AlternovaBusiness.Interface;
using AlternovaBusiness.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlternovaAPI.Controllers;

[ApiController]
[Route("[controller]/[action]")]
[Authorize]
public class AppointmentController : ControllerBase
{

    private readonly IAppointmentService _AppointmentService;

    public AppointmentController(IAppointmentService service)
    {
        _AppointmentService = service;
    }

    [HttpGet]
    public IActionResult Get([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var userIdClaim = User.FindFirst("id");
        if (userIdClaim == null)
        {
            return Unauthorized("No valid 'id' claim found in token.");
        }
        int userId = int.Parse(userIdClaim.Value);
        try
        {
            var carDetails = _AppointmentService.Get(userId, pageNumber, pageSize);
            return Ok(carDetails);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while retrieving", ex);
        }
    }

    [HttpPost()]
    public IActionResult Post([FromBody] AppointmentRequest request)
    {
        var userIdClaim = User.FindFirst("id");
        if (userIdClaim == null)
        {
            return Unauthorized("No valid 'id' claim found in token.");
        }
        int userId = int.Parse(userIdClaim.Value);
        try
        {
            var result = _AppointmentService.Post(request, userId);
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
