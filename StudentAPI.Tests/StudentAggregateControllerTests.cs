using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentAPI.Controllers;
using StudentAPI.Repository;

namespace StudentAPI.Tests
{
    [TestClass]
    public class StudentAggregateControllerTests
    {
        private IRepository _repository;
        private StudentAggregateController _controller;

        public StudentAggregateControllerTests()
        {
            _repository = new Repository.Repository();
            _controller = new StudentAggregateController(_repository);
        }

        [TestMethod]
        public void StudentAggregate_ReturnOneRecord()
        {
            var sa = _controller.Get();

            Assert.IsNotNull(sa, "StudentAggregate record");
        }
    }
}
