using MoodleBackEnd.Models.Entites.Users;

namespace MoodleBackEnd.Models.Entites
{
    public class CourseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<PhaseEntity> Phases { get; set; }
        public List<StudentEntity> Students { get; set; }
        public int InstructorId { get; set; }
        public List<InstructorCourse> Instructors { get; set; }

    }
    
}
