using MoodleBackEnd.Models.Entites.Users;

namespace MoodleBackEnd.Models.Responses
{
    public class AdminResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public int UserAccountId { get; set; }

        public Role AccountType { get; set; }
        public string Username { get; internal set; }
    }
}
