using System.Collections.Generic;

namespace ProjectSchool_API.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public List<Student> Students { get; set; }
    }
}
