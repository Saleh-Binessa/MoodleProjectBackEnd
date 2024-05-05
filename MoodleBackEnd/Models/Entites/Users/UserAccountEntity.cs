namespace MoodleBackEnd.Models.Entites.Users
{
    public class UserAccountEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; private set; }
        public bool IsAdmin { get; set; }

        private UserAccountEntity()
        {

        }
        public static UserAccountEntity Create(string username, string password, bool isAdmin)
        {
            return new UserAccountEntity
            {
                Username = username,
                Password = BCrypt.Net.BCrypt.EnhancedHashPassword(password),
                IsAdmin = isAdmin,
            };
        }
    }
}
