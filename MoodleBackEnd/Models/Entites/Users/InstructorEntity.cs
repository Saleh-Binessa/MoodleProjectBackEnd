namespace MoodleBackEnd.Models.Entites.Users
{
    public class InstructorEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int UserAccountId { get; set; }
        public UserAccountEntity Account { get; set; }
        public List<CourseEntity> Courses { get; set; }

        public InstructorEntity() { }
    }
}
