using MoodleBackEnd.Models.Entites.Users;

namespace MoodleBackEnd.Models.Requests
{
    public class AdminRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public int UserAccountId { get; set; }

        public Role AccountType { get; set; }
    }
}
