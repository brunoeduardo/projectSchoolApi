using Microsoft.AspNetCore.Mvc;

namespace ProjectSchool_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : Controller
    {
        public TeacherController()
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("{TeacherId}")]
        public IActionResult Get(int TeacherId)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }

        [HttpPut("{TeacherId}")]
        public IActionResult Put(int TeacherId)
        {
            return Ok();
        }

        [HttpDelete("{TeacherId}")]
        public IActionResult Delete(int TeacherId)
        {
            return Ok();
        }
    }
}
