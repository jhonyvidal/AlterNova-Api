using AlternovaBusiness.Interface;
using AlternovaBusiness.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlternovaAPI.Controllers
{
    [ApiController] 
    [Route("[controller]/[action]")] // Defines the route template for the controller
    [Authorize] // Requires authorization for all actions in this controller
    public class AppointmentController : ControllerBase 
    {
        private readonly IAppointmentService _AppointmentService; 

        public AppointmentController(IAppointmentService service)
        {
            // Dependency injection of appointment service
            _AppointmentService = service; 
        }

        [HttpGet]
        public IActionResult Get([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var userIdClaim = User.FindFirst("id"); 
            if (userIdClaim == null)
            {
                // Returns 401 Unauthorized if 'id' claim is missing
                return Unauthorized("No valid 'id' claim found in token."); 
            }
            int userId = int.Parse(userIdClaim.Value); 

            try
            {
                var appointments = _AppointmentService.Get(userId, pageNumber, pageSize); 
                // Returns 200 OK with the fetched appointments
                return Ok(appointments); 
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving appointments.", ex); 
            }
        }

        [HttpPost()]
        public IActionResult Post([FromBody] AppointmentRequest request)
        {
            var userIdClaim = User.FindFirst("id"); 
            if (userIdClaim == null)
            {
                // Returns 401 Unauthorized if 'id' claim is missing
                return Unauthorized("No valid 'id' claim found in token."); 
            }
            int userId = int.Parse(userIdClaim.Value); 

            try
            {
                var result = _AppointmentService.Post(request, userId);
                // Returns 200 OK with the result of the creation operation 
                return Ok(result); 
            }
            catch (Exception ex)
            {
                // Returns 500 Internal Server Error with the exception message
                return StatusCode(500, ex.Message); 
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _AppointmentService.Delete(id); 
            }
            catch (Exception ex)
            {
                // Returns 400 Bad Request with the exception message if deletion fails
                return BadRequest(ex.Message); 
            }
            // Returns 200 OK if deletion is successful
            return Ok(); 
        }
    }
}
