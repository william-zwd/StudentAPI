using Microsoft.AspNetCore.Mvc;
using StudentAPI.Models;
using StudentAPI.Repository;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private IRepository _repository;
        private List<int> _years;

        public StudentController(IRepository repository)
        {
            _repository = repository;
            _years = new List<int>();
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _repository.GetStudents();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return _repository.GetStudent(id);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
