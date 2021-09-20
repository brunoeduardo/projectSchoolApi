namespace ProjectSchool_API.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Birth { get; set; }

        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; }
    }
}
