namespace MoodleBackEnd.Models.Entites.Users
{
    public class UserAccountEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Role AccountType { get; set; }


        public StudentEntity Student { get; set; }
        public InstructorEntity Instructor { get; set; }
        public AdminEntity Admin { get; set; }

        private UserAccountEntity()
        {

        }
        public static UserAccountEntity Create(string name, string email, string username, string password, Role type)
        {
            return new UserAccountEntity
            {
                Name = name,
                Email = email,
                Username = username,
                Password = BCrypt.Net.BCrypt.EnhancedHashPassword(password),
                AccountType = Role.Admin,
            };
        }
        public bool VerifyPassword(string pwd) => BCrypt.Net.BCrypt.EnhancedVerify(pwd, Password);
    }
    public enum Role { Admin, Instructor, Student}
}
