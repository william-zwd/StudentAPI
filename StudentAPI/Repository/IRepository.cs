using StudentAPI.Models;
using System.Collections.Generic;

namespace StudentAPI.Repository
{
    public interface IRepository
    {
        public List<Student> GetStudents();
        public Student GetStudent(int id);
    }
}
