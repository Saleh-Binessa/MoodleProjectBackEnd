namespace MoodleBackEnd.Models.Entites
{
    public class SubmissionEntity
    {
        public int Id { get; set; }
        public string SubmissionLink { get; set; }
        public int TaskId { get; set; }
        public TaskEntity Task { get; set; }
        public GradeEntity Grade { get; }


    }
}
