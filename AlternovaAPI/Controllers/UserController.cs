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
        // Dependency injection of user service
        _UserService = service;
    }

    [HttpGet]
    [Authorize]
    public  IActionResult Get()
    {
        try
        {
            var carDetails =  _UserService.Get();
             // Returns 200 OK with the fetched user
            return Ok(carDetails);
        }
        catch (Exception ex)
        {
            // Returns 400 Bad Request with the exception message if deletion fails
            throw new Exception("An error occurred while retrieving", ex);
        }
    }

    [HttpPost()]
    public IActionResult Register([FromBody] User request)
    {
        try
        {
            var result = _UserService.Post(request);
             // Returns 200 OK with the fetched user
            return Ok(result); 
        }
        catch (Exception ex)
        {
            // Returns 500 Internal Server Error with the exception message
            return StatusCode(500,  ex.Message);
        }
    }

    [HttpPost()]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        try
        {
            var token = _UserService.Login(request.Email, request.Password);
             // Returns 200 OK with the fetched login
            return Ok(new { Token = token });
        }
        catch (Exception ex)
        {
            // Returns 401 Unauthorized 
            return Unauthorized(ex.Message);
        }
    }

}
