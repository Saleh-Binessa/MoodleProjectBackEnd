namespace MoodleBackEnd.Models.Entites
{
    public class GradeEntity
    {
        public int Id { get; set; }
        public double Score { get; set; }
        public int SubmissionId { get; set; }
        public SubmissionEntity Submission { get; set; }
    }
}
