namespace MoodleBackEnd.Models.Entites.Users
{
    public class AdminEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public int UserAccountId { get; set; }
        public UserAccountEntity Account { get; set; }
    }

}
