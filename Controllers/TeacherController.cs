using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectSchool_API.Data;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : Controller
    {
        public IRepository _repo { get; }

        public TeacherController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok();
            }
            catch (System.Exception)
            {
                return this
                    .StatusCode(StatusCodes.Status500InternalServerError,
                    "DB fail");
                throw;
            }
        }

        [HttpGet("{TeacherId}")]
        public IActionResult Get(int TeacherId)
        {
            try
            {
                return Ok();
            }
            catch (System.Exception)
            {
                return this
                    .StatusCode(StatusCodes.Status500InternalServerError,
                    "DB fail");
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Teacher model)
        {
            try
            {
                _repo.Add (model);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/teacher/{model.Id}", model);
                }
            }
            catch (System.Exception)
            {
                return this
                    .StatusCode(StatusCodes.Status500InternalServerError,
                    "DB fail");
                throw;
            }

            return BadRequest();
        }

        [HttpPut("{TeacherId}")]
        public IActionResult Put(int TeacherId)
        {
            try
            {
                return Ok();
            }
            catch (System.Exception)
            {
                return this
                    .StatusCode(StatusCodes.Status500InternalServerError,
                    "DB fail");
                throw;
            }
        }

        [HttpDelete("{TeacherId}")]
        public IActionResult Delete(int TeacherId)
        {
            try
            {
                return Ok();
            }
            catch (System.Exception)
            {
                return this
                    .StatusCode(StatusCodes.Status500InternalServerError,
                    "DB fail");
                throw;
            }
        }
    }
}
