using MoodleBackEnd.Models.Entites.Users;

namespace MoodleBackEnd.Models.Entites
{
    public class StudentCourse
    {
        public int StudentId { get; set; }
        public StudentEntity Student { get; set; }
        public int CourseId { get; set; }
        public CourseEntity Course { get; set; }
    }

}
