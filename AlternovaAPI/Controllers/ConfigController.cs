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
        _ConfigService = service;
    }

    [HttpGet]
    public IActionResult GetDoctor()
    {
        try
        {
            var carDetails = _ConfigService.GetDoctor();
            return Ok(carDetails);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while retrieving", ex);
        }
    }

    [HttpGet]
    public IActionResult GetType()
    {
        try
        {
            var carDetails = _ConfigService.GetType();
            return Ok(carDetails);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while retrieving", ex);
        }
    }

}
