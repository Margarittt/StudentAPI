using System.Collections.Generic;
using StudentsAPI.Models;
using StudentsAPI.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace StudentsAPI.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IDataRepository<Student> dataRepository;

        public StudentController(IDataRepository<Student> dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        // GET: api/Student
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Student> student = dataRepository.GetAll();
            return Ok(student);
        }

        // GET: api/Student/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            Student student = dataRepository.Get(id);

            if (student == null)
            {
                return NotFound("The Student record couldn't be found.");
            }

            return Ok(student);
        }

        // POST: api/Student
        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest("Student is null.");
            }

            dataRepository.Add(student);
            return CreatedAtRoute(
                  "Get",
                  new { Id = student.StudentId },
                  student);
        }

        // PUT: api/Student/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest("Student is null.");
            }

            Student studentToUpdate = dataRepository.Get(id);
            if (studentToUpdate == null)
            {
                return NotFound("The Student record couldn't be found.");
            }

            dataRepository.Update(studentToUpdate, student);
            return NoContent();
        }

        // DELETE: api/Student/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Student student = dataRepository.Get(id);
            if (student == null)
            {
                return NotFound("The Student record couldn't be found.");
            }
            dataRepository.Delete(student);
            return NoContent();
        }
    }
}