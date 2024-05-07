using MoodleBackEnd.Models.Entites;

namespace MoodleBackEnd.Models.Responses
{
    public class MaterialResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateOnly Date { get; set; }
     //   public List<TaskEntity> Tasks { get; set; }

        public MaterialResponse() { }
    }
}
