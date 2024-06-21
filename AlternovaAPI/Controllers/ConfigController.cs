using AlternovaBusiness.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlternovaAPI.Controllers;

[ApiController]
[Route("[controller]/[action]")]
[Authorize]
public class ConfigController : ControllerBase
{

    private readonly IConfigService _ConfigService;

    public ConfigController(IConfigService service)
    {
        // Dependency injection of config service
        _ConfigService = service;
    }

    [HttpGet]
    public IActionResult GetDoctor()
    {
        try
        {
            var carDetails = _ConfigService.GetDoctor();
             // Returns 200 OK with the fetched doctor
            return Ok(carDetails);
        }
        catch (Exception ex)
        {
            // Returns 400 Bad Request with the exception message if deletion fails
            throw new Exception("An error occurred while retrieving", ex);
        }
    }

    [HttpGet]
    public IActionResult GetType()
    {
        try
        {
            var carDetails = _ConfigService.GetType();
             // Returns 200 OK with the fetched types
            return Ok(carDetails);
        }
        catch (Exception ex)
        {
            // Returns 400 Bad Request with the exception message if deletion fails
            throw new Exception("An error occurred while retrieving", ex);
        }
    }

}
