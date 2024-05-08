using MoodleBackEnd.Models.Entites.Users;

namespace MoodleBackEnd.Models.Entites
{
    public class InstructorCourse
    {
        public int InstructorId { get; set; }
        public InstructorEntity Instructor { get; set; }
        public CourseEntity Course { get; set; }
        public int CourseId { get; set; }

    }
}
