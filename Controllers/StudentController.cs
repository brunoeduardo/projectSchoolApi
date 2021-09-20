using Microsoft.AspNetCore.Mvc;

namespace ProjectSchool_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        public StudentController() {

        }   

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("{StudentId}")]
        public IActionResult Get(int StudentId)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }

        [HttpPut("{StudentId}")]
        public IActionResult Put(int StudentId)
        {
            return Ok();
        }

        [HttpDelete("{StudentId}")]
        public IActionResult Delete(int StudentId)
        {
            return Ok();
        }
    }
}