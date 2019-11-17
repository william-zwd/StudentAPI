using Microsoft.AspNetCore.Mvc;
using StudentAPI.Models;
using StudentAPI.Repository;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentAggregateController : ControllerBase
    {
        private IRepository _repository;
        private List<int> _years;

        public StudentAggregateController(IRepository repository)
        {
            _repository = repository;
            _years = new List<int>();
        }

        // GET: api/<controller>
        [HttpGet]
        public StudentAggregate Get()
        {
            var sa = new StudentAggregate();
            sa.YourName = "Weidong Zhang";
            sa.YourEmail = "william_zwd@outlook.com";

            var students = _repository.GetStudents();
            GetYears(students);
            sa.YearWithHighestAttendance = GetYearWithHighestAttendance(students);
            sa.YearWithHighestOverallGpa = GetYearWithHighestOverallGpa(students);

            var query = students.OrderByDescending(s => s.GetGPA()).Take(10);
            foreach (var student in query)
            {
                sa.Top10StudentIdsWithHighestGpa.Add(student.ID);
            }

            query = students.OrderByDescending(s => s.GetGPADiff()).Take(1);
            foreach (var student in query)
            {
                sa.StudentIdMostInconsistent = student.ID;
            }

            return sa;
        }

        // GET api/<controller>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

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

        private void GetYears(List<Student> students)
        {
            foreach (var student in students)
            {
                for (int year = student.StartYear; year <= student.EndYear; year++)
                {
                    if (!_years.Contains(year))
                    {
                        _years.Add(year);
                    }
                }
            }
        }

        private int GetYearWithHighestAttendance(List<Student> students)
        {
            var yearAttendances = new Dictionary<int, int>();
            foreach (var year in _years)
            {
                yearAttendances.Add(year, students.Count(s => year >= s.StartYear && year <= s.EndYear));
            }

            var max = yearAttendances.Values.Max();
            return yearAttendances.Where(y => y.Value == max).Min(y => y.Key);
        }

        private int GetYearWithHighestOverallGpa(List<Student> students)
        {
            var yearOverallGpa = new Dictionary<int, double>();
            foreach (var year in _years)
            {
                var gpa = new List<double>();
                foreach (var student in students.Where(s => year >= s.StartYear && year <= s.EndYear))
                {
                    gpa.Add(student.GPARecord[year - student.StartYear]);
                }
                yearOverallGpa.Add(year, gpa.Average());
            }

            var max = yearOverallGpa.Values.Max();
            return yearOverallGpa.Where(y => y.Value == max).Min(y => y.Key);
        }

    }
}
