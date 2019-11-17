using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentAPI.Controllers;
using StudentAPI.Repository;

namespace StudentAPI.Tests
{
    [TestClass]
    public class StudentControllerTests
    {
        private IRepository _repository;
        private StudentController _controller;

        public StudentControllerTests()
        {
            _repository = new Repository.Repository();
            _controller = new StudentController(_repository);
        }

        [TestMethod]
        public void Student_ReturnAllStudentRecords()
        {
            var students = _controller.Get();

            Assert.IsNotNull(students, "There are students data");
        }

        [TestMethod]
        public void Student_ReturnOneStudentRecord()
        {
            var student = _controller.Get(1);

            Assert.IsNotNull(student, "There is student with ID 1");
        }

        [TestMethod]
        public void Student_ReturnNoStudentRecord()
        {
            var student = _controller.Get(100);

            Assert.IsNull(student, "There is no student with ID 100");
        }
    }
}
