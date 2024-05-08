using MoodleBackEnd.Models.Entites;

namespace MoodleBackEnd.Models.Responses
{
    public class GradeResponse
    {
        public double Score { get; set; }
        public int SubmissionId { get; set; }
        public SubmissionEntity Submission { get; set; }
        public int TaskId { get; set; }
        public TaskEntity Task { get; set; }
    }
}
