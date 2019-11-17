using System.Collections.Generic;
using System.Linq;

namespace StudentAPI.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public List<double> GPARecord { get; set; }

        public Student()
        {
            GPARecord = new List<double>();
        }

        public double GetGPA()
        {
            if (GPARecord == null || GPARecord.Count == 0)
            {
                return 0.0;
            }

            return GPARecord.Average();
        }

        public double GetGPADiff()
        {
            if (GPARecord == null || GPARecord.Count == 0)
            {
                return 0.0;
            }

            return GPARecord.Max() - GPARecord.Min();
        }
    }
}
