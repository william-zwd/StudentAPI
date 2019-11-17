using Newtonsoft.Json.Linq;
using StudentAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace StudentAPI.Repository
{
    public class Repository : IRepository
    {
        private List<Student> _students;

        public Repository()
        {
            _students = new List<Student>();

            try
            {
                var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"students.json");
                var json = File.ReadAllText(path);
                var jObject = JObject.Parse(json);

                if (jObject != null)
                {
                    JArray students = (JArray)jObject["Students"];
                    if (students != null)
                    {
                        foreach (var student in students)
                        {
                            var newStudent = new Student()
                            {
                                ID = Int32.Parse(student["Id"].ToString()),
                                Name = student["Name"].ToString(),
                                StartYear = Int32.Parse(student["StartYear"].ToString()),
                                EndYear = Int32.Parse(student["EndYear"].ToString()),
                            };

                            JArray gpas = (JArray)student["GPARecord"];
                            foreach (var gpa in gpas)
                            {
                                newStudent.GPARecord.Add(Convert.ToDouble(gpa.ToString()));
                            }

                            _students.Add(newStudent);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<Student> GetStudents()
        {
            return _students;
        }

        public Student GetStudent(int id)
        {
            return _students.FirstOrDefault(s => s.ID == id);
        }
    }
}
