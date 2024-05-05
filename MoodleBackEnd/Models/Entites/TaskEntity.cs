namespace MoodleBackEnd.Models.Entites
{
    public class TaskEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public SubmissionEntity Submission { get; set; }
    }
}
