namespace MoodleBackEnd.Models.Entites.Users
{
    public class StudentEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; private set; }
        public UserAccountEntity Account { get; set; }
    }
}
