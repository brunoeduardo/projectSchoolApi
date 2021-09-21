using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectSchool_API.Data;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        public IRepository _repo { get; }

        public StudentController(IRepository repo)
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

        [HttpGet("{StudentId}")]
        public IActionResult Get(int StudentId)
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
        public async Task<IActionResult> Post(Student model)
        {
            try
            {
                _repo.Add (model);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/student/{model.Id}", model);
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

        [HttpPut("{StudentId}")]
        public IActionResult Put(int StudentId)
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

        [HttpDelete("{StudentId}")]
        public IActionResult Delete(int StudentId)
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
