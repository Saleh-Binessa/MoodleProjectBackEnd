namespace MoodleBackEnd.Models.Entites
{
    public class SubmissionEntity
    {
        public int Id { get; set; }
        public string SubmissionLink { get; set; }
        public GradeEntity Grade { get; }
    }
}
