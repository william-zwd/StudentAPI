using System.Collections.Generic;

namespace StudentAPI.Models
{
    public class StudentAggregate
    {
        public string YourName { get; set; }
        public string YourEmail { get; set; }
        public int YearWithHighestAttendance { get; set; }
        public int YearWithHighestOverallGpa { get; set; }
        public List<int> Top10StudentIdsWithHighestGpa { get; set; }
        public int StudentIdMostInconsistent { get; set; }

        public StudentAggregate()
        {
            Top10StudentIdsWithHighestGpa = new List<int>();
        }
    }
}
