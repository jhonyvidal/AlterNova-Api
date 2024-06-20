using AlternovaBusiness.Interface;
using AlternovaBusiness.Models;
using AlternovaData.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlternovaAPI.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class UserController : ControllerBase
{

    private readonly IUserService _UserService;

    public UserController(IUserService service)
    {
        _UserService = service;
    }

    [HttpGet]
    [Authorize]
    public  IActionResult Get()
    {
        try
        {
            var carDetails =  _UserService.Get();
            return Ok(carDetails);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while retrieving", ex);
        }
    }

    [HttpPost()]
    public IActionResult Register([FromBody] User request)
    {
        try
        {
            var result = _UserService.Post(request);
            return Ok(result); 
        }
        catch (Exception ex)
        {
            return StatusCode(500,  ex.Message);
        }
    }

    [HttpPost()]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        try
        {
            var token = _UserService.Login(request.Email, request.Password);
            return Ok(new { Token = token });
        }
        catch (Exception ex)
        {
            return Unauthorized(ex.Message);
        }
    }

}
