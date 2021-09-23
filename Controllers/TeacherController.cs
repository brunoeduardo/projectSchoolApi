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
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllTeachersAsync(true);
                return Ok(result);
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
        public async Task<IActionResult> GetTeacherById(int TeacherId)
        {
            try
            {
                var result = await _repo.GetTeacherAsyncById(TeacherId, true);
                return Ok(result);
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
        public async Task<IActionResult> Put(int TeacherId, Teacher model)
        {
            try
            {
                var teacher = await _repo.GetTeacherAsyncById(TeacherId, false);
                if (teacher == null) return NotFound();

                _repo.Update (model);

                if (await _repo.SaveChangesAsync())
                {
                    teacher = await _repo.GetTeacherAsyncById(TeacherId, true);
                    return Created($"/api/teacher/{model.Id}", teacher);
                }

                return BadRequest();
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
        public async Task<IActionResult> Delete(int TeacherId, Teacher model)
        {
            try
            {
                var teacher = await _repo.GetTeacherAsyncById(TeacherId, false);
                if (teacher == null) return NotFound();

                _repo.Delete (teacher);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok();
                }

                return BadRequest();
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
