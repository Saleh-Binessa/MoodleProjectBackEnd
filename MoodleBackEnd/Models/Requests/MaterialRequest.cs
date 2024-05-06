using MoodleBackEnd.Models.Entites;

namespace MoodleBackEnd.Models.Requests
{
    public class MaterialRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
     //   public List<TaskEntity> Tasks { get; set; }
    }
}
