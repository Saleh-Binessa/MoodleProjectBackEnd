namespace MoodleBackEnd.Models.Entites
{
    public class TaskEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MaterialId { get; set; }
        public MaterialEntity Material { get; set; }

        public int SubmissionEntityId { get; set; }
        public SubmissionEntity Submission { get; set; }
        public DateTime DeadLine { get; set; }
    }
}
