namespace MoodleBackEnd.Models.Entites.Users
{
    public class StudentEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public UserAccountEntity Account { get; set; }
        public int CourseId { get; set; }
        public CourseEntity Course { get; set; }
        public StudentEntity() { }
    }
}
