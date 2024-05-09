using MoodleBackEnd.Models.Entites;

namespace MoodleBackEnd.Models.Requests
{
    public class GradeRequest
    {
        public double Score { get; set; } 
        public int SubmissionId { get; set; }
        public int TaskId { get; set; }
        public TaskEntity Task { get; set; } 
    }
}
