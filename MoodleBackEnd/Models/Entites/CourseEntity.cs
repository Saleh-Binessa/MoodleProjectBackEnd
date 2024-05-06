using MoodleBackEnd.Models.Entites.Users;

namespace MoodleBackEnd.Models.Entites
{
    public class CourseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<PhaseEntity> Phases { get; set; }
        public List<StudentCourse> Students { get; set; }
        public int InstructorId { get; set; }
        public InstructorEntity Instructor { get; set; }

        public CourseEntity() { }
    }
    
}
