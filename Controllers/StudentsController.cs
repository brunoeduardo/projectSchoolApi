using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectSchool_API.Data;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : Controller
    {
        public IRepository _repo { get; }

        public StudentsController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllStudentsAsync(true);
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

        [HttpGet("{StudentId}")]
        public async Task<IActionResult> GetByStudentId(int StudentId)
        {
            try
            {
                var result = await _repo.GetStudentAsyncById(StudentId, true);
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

        [HttpGet("Teacher/{TeacherId}")]
        public async Task<IActionResult> GetStudentByTeacherId(int TeacherId)
        {
            try
            {
                var result =
                    await _repo.GetStudentsAsyncByTeacherId(TeacherId, true);
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
        public async Task<IActionResult> Post(Student model)
        {
            try
            {
                _repo.Add (model);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/students/{model.Id}", model);
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
        public async Task<IActionResult> Put(int StudentId, Student model)
        {
            try
            {
                var student = await _repo.GetStudentAsyncById(StudentId, false);
                if (student == null) return NotFound();

                _repo.Update (model);

                if (await _repo.SaveChangesAsync())
                {
                    student = await _repo.GetStudentAsyncById(StudentId, true);
                    return Created($"/api/students/{model.Id}", student);
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

        [HttpDelete("{StudentId}")]
        public async Task<IActionResult> Delete(int StudentId, Student model)
        {
            try
            {
                var student = await _repo.GetStudentAsyncById(StudentId, false);
                if (student == null) return NotFound();

                _repo.Delete (student);

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
