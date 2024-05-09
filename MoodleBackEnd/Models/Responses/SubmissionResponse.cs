using MoodleBackEnd.Models.Entites;

namespace MoodleBackEnd.Models.Responses
{
    public class SubmissionResponse
    {
        public string SubmissionLink { get; set; }
        public DateTime Date { get; set; }
        public TaskEntity Task { get; set; }
        public GradeEntity Grade { get; }
    }
}
