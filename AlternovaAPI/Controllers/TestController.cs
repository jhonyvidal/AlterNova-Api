using AlternovaBusiness.Interfaces;
using AlternovaData.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AlternovaAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TestController : Controller
    {
        private readonly ITest _testService;

        public TestController(ITest service)
        {
            _testService = service;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_testService.Get());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var Personal = _testService.Get(id);
            if (Personal == null)
                return NotFound();

            return Ok(Personal);
        }

        [HttpPost]
        public IActionResult Post([FromBody] TestEntitie request)
        {
            try
            {
                var result = _testService.Post(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] TestEntitie request)
        {
            try
            {
                _testService.Update(id, request);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Personal = _testService.Get(id);

            if (Personal == null)
                return NotFound();
            try
            {
                _testService.Delete(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
