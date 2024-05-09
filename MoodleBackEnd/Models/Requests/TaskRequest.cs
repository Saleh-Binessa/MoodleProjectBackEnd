using MoodleBackEnd.Models.Entites;

namespace MoodleBackEnd.Models.Requests
{
    public class TaskRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DeadLine { get; set; }
        public int MaterialId { get; set; }

    }
}
